using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Hubs.ChatModels
{
    public class FetchChatsOutput
    {
        public FetchChatsOutput(IEnumerable<UserToChatDatabase> results, byte[] pagingState, Guid userId)
        {
            Results = results;
            PagingState = pagingState;
            UserId = userId;
        }


        public IEnumerable<UserToChatDatabase> Results { get; }
        public byte[] PagingState { get; }
        public Guid UserId { get; }
    }
}
