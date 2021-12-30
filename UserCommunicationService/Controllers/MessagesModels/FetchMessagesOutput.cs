using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class FetchMessagesOutput
    {
        public FetchMessagesOutput(IEnumerable<MessageDatabase> messages, byte[] pagingState, string chatId)
        {
            Messages = messages;
            ChatId = chatId;
            PagingState = pagingState;
        }


        public IEnumerable<MessageDatabase> Messages { get; }
        public byte[] PagingState { get; }
        public string ChatId { get; }
    }
}
