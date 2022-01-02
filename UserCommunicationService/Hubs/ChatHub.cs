using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using UserCommunicationService.Controllers.MessagesModels;
using UserCommunicationService.Core.Services.Chats;
using UserCommunicationService.Core.Services.Messages;
using UserCommunicationService.database.Repositories.Chats.Models;
using UserCommunicationService.Hubs.ChatModels;
using UserCommunicationService.Hubs.HubModels;

namespace UserCommunicationService.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub(
            IMessagesService messagesService,
            IChatsService chatsService,
            IDistributedCache distributedCache,
            ILogger<ChatHub> logger)
        {
            _messagesService = messagesService;
            _chatsService = chatsService;
            _logger = logger;
        }


        private ILogger<ChatHub> _logger;
        private IMessagesService _messagesService;
        private IChatsService _chatsService;
        private IDistributedCache _distributedCache;

        // user id to connections mapper
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();


        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task InitConnectedUser(InitConnectedUserInput input)
        {
            _connections.Add(input.UserId.ToString(), Context.ConnectionId);

            var fetch = new FetchChatsInput(userId: input.UserId, pageSize: input.MaxChats, pagingState: null);
            var page = _chatsService.FetchChats(fetch.ToCore());
            foreach (var item in page)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, item.ChatId.ToString());
            }
        }

        public async Task CreateDialog(CreateDialogInput input)
        {
            var chatId = Guid.NewGuid();
            var row1 = new UserToChatDatabase(userId: input.FirstUserId, chatId: chatId);
            var row2 = new UserToChatDatabase(userId: input.SecondUserId, chatId: chatId);
            var list = new List<UserToChatDatabase>() { row1, row2 };
            await _chatsService.AddUsersToChat(list);

            await AddUserConnectionsToGroup(row1.UserId.ToString(), chatId.ToString());
            await AddUserConnectionsToGroup(row2.UserId.ToString(), chatId.ToString());
        }

        public async Task AddUserToChat(AddUserToChatInput input)
        {
            var row = new UserToChatDatabase(userId: input.UserId, chatId: input.ChatId);
            var list = new List<UserToChatDatabase>() { row };
            await _chatsService.AddUsersToChat(list);

            await AddUserConnectionsToGroup(input.UserId.ToString(), input.ChatId.ToString());
        }

        public async Task SendMessage(SendMessageInput input)
        {
            var coreModel = input.ToCoreModel(DateTime.Now);
            var chatId = coreModel.ChatId;

            // save to database 
            await _messagesService.SaveMessage(coreModel);

            // increase notifications counter (not read messages)
            await _chatsService.IncrementNotificationsCounter(chatId, coreModel.FromId);

            var receiveMessage = new ReceiveMessage(coreModel.ToReceiveMessageCore());
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
                var output = new UserToChatOutput(userId: dbChat.UserId, chatId: dbChat.ChatId, newMessagesCount: newMessagesCount[i]);
                chats.Add(output);
            }

            var result = new FetchChatsOutput(chats, pagingState: page.PagingState, userId: input.UserId);
            await Clients.Caller.SendAsync(HubMethodsNames.FetchingChats, result);
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
