using UserCommunicationService.Core.Services.Messages.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class FetchMessagesInput
    {
        public FetchMessagesInput(int pageSize, byte[] pagingState, Guid chatId)
        {
            PageSize = pageSize;
            PagingState = pagingState;
            ChatId = chatId;
        }


        public int PageSize { get; }
        public byte[] PagingState { get; }
        public Guid ChatId { get; set; }

        public FetchMessagesInputCore ToCore()
        {
            return new FetchMessagesInputCore(PageSize, PagingState, chatId: ChatId);
        }
    }
}
