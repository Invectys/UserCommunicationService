using UserCommunicationService.Core.Services.Chats.ChatsModels;

namespace UserCommunicationService.Hubs.ChatModels
{
    public class FetchChatUsersInput
    {
        public FetchChatUsersInput(Guid chatId, int pageSize, byte[] pagingState)
        {
            ChatId = chatId;
            PagingState = pagingState;
            PageSize = pageSize;
        }


        public Guid ChatId { get; }
        public int PageSize { get; }
        public byte[] PagingState { get; }


        public FetchChatUsersInputCore ToCore()
        {
            return new FetchChatUsersInputCore(ChatId, PageSize, PagingState); 
        }
    }
}
