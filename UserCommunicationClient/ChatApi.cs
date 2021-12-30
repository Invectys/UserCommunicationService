using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private byte[]? _pagingState = null;
        private int _pageSize = 5;
        private string _uid;

        public async Task Init()
        {
            CreateConnection();
            await Start();
            BindRPC();
        }

        public async Task FetchMessages(string chatId)
        {
            var fetch = new FetchMessagesInput(_pageSize, _pagingState, chatId);
            await _connection.SendAsync("FetchMessages", fetch);
        }

        public async Task SendMessage(string toId, string chatId, string message)
        {
            var input = new SendMessageInput(fromId: new Guid(_uid), toId: new Guid(toId), chatId: new Guid(chatId), content: message);
            await _connection.SendAsync("SendMessage", input);
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
                Console.WriteLine("chatId=" + message.ChatId + " from:" + message.FromId.ToString() + ":" + message.Content);
            });

            _connection.On<FetchMessagesOutput>("FetchingMessagesHistory", (output) =>
            {
                Console.WriteLine("fetched messages");
                _pagingState = output.PagingState;
                foreach (var item in output.Messages)
                {
                    Console.WriteLine($"{item.CreationTime.ToShortDateString()}: from={item.FromId} to={item.ToId} content={item.Content}");
                }
            });
        }

    }
}
