using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Hubs.ChatModels
{
    public class FetchChatUsersOutput
    {
        public FetchChatUsersOutput(IEnumerable<ChatToUserDatabase> results, byte[] pagingState, Guid chatId)
        {
            Results = results;
            PagingState = pagingState;
            ChatId = chatId;
        }


        public IEnumerable<ChatToUserDatabase> Results { get; }
        public byte[] PagingState { get; }
        public Guid ChatId { get; }
    }
}
