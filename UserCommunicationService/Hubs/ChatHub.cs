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
            var coreModel = input.ToCoreModel(DateTime.Now);
            var chatId = coreModel.ChatId;

            await _messagesService.SaveMessage(coreModel);

            var receiveMessage = new ReceiveMessage(coreModel.ToReceiveMessageCore());
            await Clients.Group(chatId.ToString()).SendAsync(HubMethodsNames.NewMessageName, receiveMessage);
            

            _logger.LogInformation($"Sending message {input.FromId} to {input.ToId} content: {input.Content}");
        }

        public async Task FetchMessages(FetchMessagesInput input)
        {
            var page = _messagesService.FetchMessages(input.ToCore());
            var result = new FetchMessagesOutput(page, pagingState: page.PagingState, chatId: input.ChatId);
            await Clients.Caller.SendAsync(HubMethodsNames.FetchingMessagesHistory, result);
        }
    }
}
