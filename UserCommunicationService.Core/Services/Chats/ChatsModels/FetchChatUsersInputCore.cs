using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services.Chats.ChatsModels
{
    public class FetchChatUsersInputCore
    {
        public FetchChatUsersInputCore(Guid chatId, int pageSize, byte[] pagingState)
        {
            ChatId = chatId;
            PagingState = pagingState;
            PageSize = pageSize;
        }


        public Guid ChatId { get; }
        public int PageSize { get; }
        public byte[] PagingState { get; }
    }
}
