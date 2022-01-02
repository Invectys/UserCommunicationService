using Cassandra.Mapping;
using UserCommunicationService.Core.Services.Chats.ChatsModels;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Core.Services.Chats
{
    public interface IChatsService
    {

        IPage<ChatToUserDatabase> FetchChatUsers(FetchChatUsersInputCore input);
        IPage<UserToChatDatabase> FetchChats(FetchChatsInputCore input);
        Task AddUsersToChat(List<UserToChatDatabase> row);

        Task IncrementNotificationsCounter(Guid chatId, Guid senderId);
        Task AddToNotificationCount(int addMessasgesCount, Guid chatId, Guid userId);
        Task<int> GetChatNewMessagesCount(Guid chatId, Guid userId);
        Task ClearChatNotifications(Guid chatId, Guid userId);
        Task<int[]> GetChatsNewMessagesCount(IEnumerable<UserToChatDatabase> chats);
    }
}
