using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services.Chats.ChatsModels
{
    public class FetchChatsInputCore
    {
        public FetchChatsInputCore(Guid userId, byte[] pagingState, int pageSize = 5)
        {
            UserId  = userId;
            PagingState = pagingState;
            PageSize = pageSize;
        }


        public int PageSize { get; set; }
        public Guid UserId { get;  }
        public byte[] PagingState { get; }
    }
}
