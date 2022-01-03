using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Hubs.ChatModels
{
    public class FetchChatsOutput
    {
        public FetchChatsOutput(IEnumerable<UserToChatOutput> results, byte[] pagingState, string userId)
        {
            Results = results;
            PagingState = pagingState;
            UserId = userId;
        }


        public IEnumerable<UserToChatOutput> Results { get; }
        public byte[] PagingState { get; }
        public string UserId { get; }
    }
}
