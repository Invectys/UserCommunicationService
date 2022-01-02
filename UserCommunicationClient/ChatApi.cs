using Microsoft.AspNetCore.SignalR.Client;
using UserCommunicationClient.api;

namespace UserCommunicationClient
{
    public class ChatApi
    {
        public ChatApi(string chatHubUrl, string uid)
        {
            _chatHubUrl = chatHubUrl;
            _uid = uid;
        }


        private HubConnection _connection;
        private string _chatHubUrl;
        private int _pageSize = 5;
        private string _uid;

        private Dictionary<string, byte[]> PagingStates = new Dictionary<string, byte[]>();

        public async Task Init()
        {
            CreateConnection();
            await Start();
            await InitConnectedUser();
            BindRPC();
        }

        public async Task Stop()
        {
            await _connection.StopAsync();
            await _connection.DisposeAsync();
        }

        public async Task AddUserToChat(Guid userId, Guid chatId)
        {
            var input = new AddUserToChatInput(userId, chatId);
            await _connection.SendAsync("AddUserToChat", input);
        }

        public async Task FetchMessages(Guid chatId)
        {
            var messagesId = chatId.ToString() + "-messages";
            PagingStates.TryGetValue(messagesId, out var state);
            var fetch = new FetchMessagesInput(_pageSize, state, chatId);
            await _connection.SendAsync("FetchMessages", fetch);
        }

        public async Task FetchChats(Guid userId)
        {
            var userChatsPaging = userId + "-chats";
            PagingStates.TryGetValue(userChatsPaging, out var state);
            var fetch = new FetchChatsInput(userId: userId, pagingState: state);
            await _connection.SendAsync("FetchChats", fetch);
        }

        public async Task CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            var input = new CreateDialogInput(firstUserId: firstUserId, secondUserId: secondUserId);
            await _connection.SendAsync("CreateDialog", input);
        }

        public async Task SendMessage(Guid chatId, string message, Guid? toId = null)
        {
            var input = new SendMessageInput(fromId: new Guid(_uid), toId: toId, chatId: chatId, content: message);
            await _connection.SendAsync("SendMessage", input);
        }

        public async Task ClearChatNotifications(Guid chatId, Guid userId)
        {
            var input = new ClearChatNotificationsInput(chatId, userId);
            await _connection.SendAsync("ClearChatNotifications", input);
        }

        private void CreateConnection()
        {
            _connection = new HubConnectionBuilder()
            .WithUrl(_chatHubUrl)
            .Build();
        }

        private async Task Start()
        {
            await _connection.StartAsync();
        }

        private void BindRPC()
        {
            _connection.On<ReceiveMessage>("NewMessage", (message) =>
            {
                Console.WriteLine("NewMessage! chatId=" + message.ChatId + " from:" + message.FromId.ToString() + ": " + message.Content);
            });

            _connection.On<FetchMessagesOutput>("FetchingMessagesHistory", (output) =>
            {
                Console.WriteLine("fetched messages Chat = " + output.ChatId);
                PagingStates[output.ChatId.ToString() + "-messages"] = output.PagingState;
                foreach (var item in output.Messages)
                {
                    Console.WriteLine($"{item.CreationTimeStamp.ToShortTimeString()} from={item.FromId}: {item.Content}");
                }
            });

            _connection.On<FetchChatsOutput>("FetchingChats", (output) =>
            {
                Console.WriteLine("fetched chats");
                PagingStates[output.UserId.ToString() + "-chats"] = output.PagingState;
                foreach (var item in output.Results)
                {
                    Console.WriteLine($"Chat id = {item.ChatId}, (new {item.NewMessagesCount}) ");
                }
            });
        }

        private async Task InitConnectedUser()
        {
            var init = new InitConnectedUserInput(new Guid(_uid));
            await _connection.SendAsync("InitConnectedUser", init);
        }
    }
}
