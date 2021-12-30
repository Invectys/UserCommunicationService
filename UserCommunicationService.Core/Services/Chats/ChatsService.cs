using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunicationService.Core.Services.Chats.ChatsModels;
using UserCommunicationService.database.Repositories;
using UserCommunicationService.database.Repositories.Chats;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Core.Services.Chats
{
    public class ChatsService : IChatsService
    {
        public ChatsService(
            ChatsRepository chatsRepository)
        {
            _chatsRepository = chatsRepository;
        }


        private ChatsRepository _chatsRepository;


        public async Task AddUsersToChat(List<UserToChatDatabase> row)
        {
            await _chatsRepository.InsertMany(row);
        }

        public IPage<UserToChatDatabase> FetchChats(FetchChatsInputCore input)
        {
            var result = _chatsRepository.FetchChats(pageSize: input.PageSize, pagingState: input.PagingState, userId: input.UserId.ToString());
            return result;
        }
    }
}
