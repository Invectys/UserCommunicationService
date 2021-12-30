using Cassandra.Mapping;
using UserCommunicationService.Core.Services.Chats.ChatsModels;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Core.Services.Chats
{
    public interface IChatsService
    {

        IPage<UserToChatDatabase> FetchChats(FetchChatsInputCore input);
        Task AddUsersToChat(List<UserToChatDatabase> row);

    }
}
