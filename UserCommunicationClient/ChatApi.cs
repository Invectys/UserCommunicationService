using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using UserCommunicationClient.api;

namespace UserCommunicationClient
{
    public class ChatApi
    {
        public ChatApi(string chatHubUrl, string uid, string token)
        {
            _chatHubUrl = chatHubUrl;
            _uid = uid;
            _token = token;
        }

        private string? _token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjFkMmE2YTZhNDcyYWNhNjNmM2FmNzU2NjIxZjM0Njg2OTI1YjUxYTgiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vdHVzYW5ldHdvcmt2MyIsImF1ZCI6InR1c2FuZXR3b3JrdjMiLCJhdXRoX3RpbWUiOjE2NDEyMjIwNzQsInVzZXJfaWQiOiJYQ1dtQm5VN1VxUzFtZ1V5b2lmUTVEcWlkVXMyIiwic3ViIjoiWENXbUJuVTdVcVMxbWdVeW9pZlE1RHFpZFVzMiIsImlhdCI6MTY0MTIyMjA3NCwiZXhwIjoxNjQxMjI1Njc0LCJwaG9uZV9udW1iZXIiOiIrNzk3Nzc3Nzc3NzciLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7InBob25lIjpbIis3OTc3Nzc3Nzc3NyJdfSwic2lnbl9pbl9wcm92aWRlciI6InBob25lIn19.PCYr_YWj1ha5L2xUAoqYI-eKWlYHmtEVgfTrAyv6SjD3lMql4vHMLQSltveGq05UBDG43ksAV-u44G4N2Q45rJcCgBjzDHMj_Btg08WHwloz0mk2kl0rSWwg_KDVLj7JqysYqhrLzxEQ8KgrjP2o4gTQtALxyVrIagyzWvicqCttjpkZ4S0a86Gi9wygzDIUM9zEji0BmUKRKAYPps2Hq3Ttni91maRGDu015wXv3FMnPgXX1XWkUP7MUVIsdyCne_xSOIxwvHPjtwnpD_QT25xP1sMlzlhsE2thw-LjcpSVXGucE3_nCPsaCiICjPb0oF9cp9zW0NttXce502077Q";

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

        public async Task AddUserToChat(string userId, Guid chatId)
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

        public async Task FetchChats(string userId)
        {
            var userChatsPagingKey = userId + "-chats";
            PagingStates.TryGetValue(userChatsPagingKey, out var state);
            var fetch = new FetchChatsInput(userId: userId, pagingState: state);
            await _connection.SendAsync("FetchChats", fetch);
        }

        public async Task FetchingChatUsers(Guid chatId)
        {
            var userChatsPaging = chatId.ToString() + "-userchats";
            PagingStates.TryGetValue(userChatsPaging, out var state);
            var input = new FetchChatUsersInput(chatId, 10, state);
            await _connection.SendAsync("FetchingChatUsers", input);
        }

        public async Task CreateDialog(string firstUserId, string secondUserId)
        {
            var input = new CreateDialogInput(firstUserId: firstUserId, secondUserId: secondUserId);
            await _connection.SendAsync("CreateDialog", input);
        }

        public async Task SendMessage(Guid chatId, string message, string? toId = null)
        {
            var input = new SendMessageInput(fromId: _uid, toId: toId, chatId: chatId, content: message);
            await _connection.SendAsync("SendMessage", input);
        }

        public async Task ClearChatNotifications(Guid chatId, string userId)
        {
            var input = new ClearChatNotificationsInput(chatId, userId);
            await _connection.SendAsync("ClearChatNotifications", input);
        }

        private void CreateConnection()
        {
            _connection = new HubConnectionBuilder()
            .WithUrl(_chatHubUrl, options =>
            {
                options.Transports = HttpTransportType.WebSockets;
                options.SkipNegotiation = true;
                options.AccessTokenProvider = () => Task.Run(() => _token);
            })
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

            _connection.On<FetchChatUsersOutput>("FetchingChatUsers", (output) =>
            {
                Console.WriteLine("fetched users of chat");
                PagingStates[output.ChatId.ToString() + "-userchats"] = output.PagingState;
                foreach (var item in output.Results)
                {
                    Console.WriteLine($"User id = {item.UserId}, ");
                }
            });
        }

        private async Task InitConnectedUser()
        {
            var init = new InitConnectedUserInput(_uid);
            await _connection.SendAsync("InitConnectedUser", init);
        }
    }
}
