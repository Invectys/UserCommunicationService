using UserCommunicationService.Core.Services.Messages.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class FetchMessagesInput
    {
        public FetchMessagesInput(int pageSize, byte[] pagingState, string chatId)
        {
            PageSize = pageSize;
            PagingState = pagingState;
            ChatId = chatId;
        }


        public int PageSize { get; }
        public byte[] PagingState { get; }
        public string ChatId { get; set; }

        public FetchMessagesInputCore ToCore()
        {
            return new FetchMessagesInputCore(PageSize, PagingState, chatId: ChatId);
        }
    }
}
