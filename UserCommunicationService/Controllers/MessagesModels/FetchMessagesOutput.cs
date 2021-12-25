using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class FetchMessagesOutput
    {
        public FetchMessagesOutput(IEnumerable<MessageDatabase> messages, byte[] pagingState)
        {
            Messages = messages;
            PagingState = pagingState;
        }


        public IEnumerable<MessageDatabase> Messages { get; }
        public byte[] PagingState { get; }
    }
}
