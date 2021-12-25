namespace UserCommunicationService.Core.Services.Messages.MessagesModels
{
    public class FetchMessagesInputCore
    {
        public FetchMessagesInputCore(int pageSize, byte[] pagingState, string chatId)
        {
            PageSize = pageSize;
            PagingState = pagingState;
            ChatId = chatId;
        }


        public int PageSize { get; }
        public byte[] PagingState { get; }
        public string ChatId { get; set; }
    }
}
