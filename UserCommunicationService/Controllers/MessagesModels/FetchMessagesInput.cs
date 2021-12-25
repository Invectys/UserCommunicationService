using UserCommunicationService.Core.Services.Messages.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class FetchMessagesInput
    {
        public FetchMessagesInput(int pageSize, byte[] pagingState, Guid companionId)
        {
            PageSize = pageSize;
            PagingState = pagingState;
            СompanionUid = companionId;
        }


        public int PageSize { get; }
        public byte[] PagingState { get; }
        public Guid СompanionUid { get; set; }

        public FetchMessagesInputCore ToCore()
        {
            return new FetchMessagesInputCore(PageSize, PagingState);
        }
    }
}
