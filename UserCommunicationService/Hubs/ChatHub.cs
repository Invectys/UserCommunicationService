using Microsoft.AspNetCore.SignalR;
using UserCommunicationService.Controllers.MessagesModels;
using UserCommunicationService.Core.Services.Messages;

namespace UserCommunicationService.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub(
            IMessagesService messagesService,
            ILogger<ChatHub> logger)
        {
            _messagesService = messagesService;
            _logger = logger;
        }


        private ILogger<ChatHub> _logger;
        private IMessagesService _messagesService;


        public async Task SendMessage(SendMessageInput input)
        {
            _logger.LogInformation($"Sending message {input.FromId} to {input.ToId} content: {input.Content}");
            var toId = input.ToId.ToString();
            await Clients.User(toId).SendAsync(HubMethodsNames.NewMessageName, input.Content);
            await _messagesService.SaveMessage(input.ToCoreModel(DateTime.Now));
        }

        public async Task FetchMessages(FetchMessagesInput input)
        {
            var page = _messagesService.FetchMessages(input.ToCore());
            var result = new FetchMessagesOutput(page, page.PagingState);
            await Clients.Caller.SendAsync(HubMethodsNames.FetchingMessagesHistory, result);
        }
    }
}
