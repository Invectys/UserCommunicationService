﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using UserCommunicationService.Controllers.MessagesModels;
using UserCommunicationService.Core.Constants;
using UserCommunicationService.Core.Services.Chats;
using UserCommunicationService.Core.Services.Messages;
using UserCommunicationService.Core.Services.Users;
using UserCommunicationService.database.Repositories.Chats.Models;
using UserCommunicationService.Hubs.ChatModels;

namespace UserCommunicationService.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public ChatHub(
            IMessagesService messagesService,
            IChatsService chatsService,
            IUsersService usersService,
            ILogger<ChatHub> logger)
        {
            _messagesService = messagesService;
            _chatsService = chatsService;
            _usersService = usersService;
            _logger = logger;
        }


        private ILogger<ChatHub> _logger;
        private IMessagesService _messagesService;
        private IChatsService _chatsService;
        private IUsersService _usersService;

        // user id to connections mapper
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();


        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier!;
            _connections.Add(userId, Context.ConnectionId);

            // add connection to group by all chats that have
            var fetch = new FetchChatsInput(userId: userId, pageSize: 1000000, pagingState: null);
            var page = _chatsService.FetchChats(fetch.ToCore());
            foreach (var item in page)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, item.ChatId.ToString());
            }

            await base.OnConnectedAsync();
        }

        public async Task CreateDialog(CreateDialogInput input)
        {
            // fetching information about user in third part authrntication service (eg firebase or IdentityServer)
            var fetchedUsers = await _usersService.FetchUsers(new string[] { input.FirstUserId, input.SecondUserId });

            var firstUser = fetchedUsers.First(u => u.UserId == input.FirstUserId);
            var secondUSer = fetchedUsers.First(u => u.UserId == input.SecondUserId);

            var chatId = Guid.NewGuid();

            var row1 = new UserToChatDatabase(userId: input.FirstUserId, 
                chatId: chatId, banned: false, chatName: secondUSer.PrivateChatNameWithThisUser, role: Roles.User, notificationsEnabled: true);

            var row2 = new UserToChatDatabase(userId: input.SecondUserId, 
                chatId: chatId, banned: false, chatName: firstUser.PrivateChatNameWithThisUser, role: Roles.User, notificationsEnabled: true);

            // save to database
            var list = new List<UserToChatDatabase>() { row1, row2 };
            await _chatsService.AddUsersToChat(list);

            // add users to chat notifications group
            await HandleAddUserToChatNotifications(row1);
            await HandleAddUserToChatNotifications(row2);
        }

        public async Task CreateGroupChat(CreateGroupChatInput input)
        {
            var chatId = Guid.NewGuid();
            var rows = new List<UserToChatDatabase>();
            foreach (var item in input.Users)
            {
                var row = new UserToChatDatabase(item, chatId, banned: false, notificationsEnabled: true, chatName: input.ChatName, role: Roles.User);
                rows.Add(row);
                // add users to chat notifications group
                await HandleAddUserToChatNotifications(row);
            }

            // save to database
            await _chatsService.AddUsersToChat(rows);
        }

        public async Task AddUserToChat(AddUserToChatInput input)
        {
            var row = new UserToChatDatabase(userId: input.UserId, chatId: input.ChatId, 
                banned: false, notificationsEnabled: false, chatName: input.ChatName, role: Roles.User);
            var list = new List<UserToChatDatabase>() { row };
            await _chatsService.AddUsersToChat(list);

            await HandleAddUserToChatNotifications(row);
        }

        public async Task SendMessage(SendMessageInput input)
        {
            var coreModel = input.ToCoreModel(DateTime.Now);
            var chatId = coreModel.ChatId;

            // save to database 
            var guid = await _messagesService.SaveMessage(coreModel);

            // increase notifications counter (not read messages)
            await _chatsService.IncrementNotificationsCounter(chatId, coreModel.FromId);

            var receiveMessage = new ReceiveMessage(coreModel.ToReceiveMessageCore(guid));
            await Clients.Group(chatId.ToString()).SendAsync(HubMethodsNames.NewMessageName, receiveMessage);
            

            _logger.LogInformation($"Sending message {input.FromId} to {input.ToId} content: {input.Content}");
        }

        public async Task ClearChatNotifications(ClearChatNotificationsInput input)
        {
            await _chatsService.ClearChatNotifications(input.ChatId, input.UserId);
        }

        public async Task FetchMessages(FetchMessagesInput input)
        {
            var page = _messagesService.FetchMessages(input.ToCore());
            var result = new FetchMessagesOutput(page, pagingState: page.PagingState, chatId: input.ChatId);
            await Clients.Caller.SendAsync(HubMethodsNames.FetchingMessagesHistory, result);
        }

        public async Task FetchChatUsers(FetchChatUsersInput input)
        {
            var page = _chatsService.FetchChatUsers(input.ToCore());
            var output = new FetchChatUsersOutput(page, page.PagingState, input.ChatId);
            await Clients.Caller.SendAsync(HubMethodsNames.FetchingChatUsers, output);
        }

        public async Task FetchChats(FetchChatsInput input)
        {
            var page = _chatsService.FetchChats(input.ToCore());
            var items = page.ToList();

            var newMessagesCount = await _chatsService.GetChatsNewMessagesCount(page);
            var chats = new List<UserToChatOutput>();
            for(int i = 0; i < page.Count; i++)
            {
                var dbChat = items[i];
                var newMessages = newMessagesCount[i];
                var output = UserToChatOutput.FromDatabase(dbChat, newMessages);
                chats.Add(output);
            }

            var result = new FetchChatsOutput(chats, pagingState: page.PagingState, userId: input.UserId);
            await Clients.Caller.SendAsync(HubMethodsNames.FetchingChats, result);
        }

        private async Task HandleAddUserToChatNotifications(UserToChatDatabase input)
        {
            await NewChatSendNotifiication(input);
            await AddUserConnectionsToGroup(input.UserId, input.ChatId.ToString());
        }

        private async Task NewChatSendNotifiication(UserToChatDatabase input)
        {
            UserToChatOutput output = UserToChatOutput.FromDatabase(input, 0);
            var firstConenctions = _connections.GetConnections(input.UserId);
            foreach (var item in firstConenctions)
            {
                await Clients.Client(item).SendAsync(HubMethodsNames.NewChat, output);
            }
        }

        private async Task AddUserConnectionsToGroup(string userId, string group)
        {
            foreach (var connectionId in _connections.GetConnections(userId))
            {
                await Groups.AddToGroupAsync(connectionId, group);
            }
        }
    }
}
