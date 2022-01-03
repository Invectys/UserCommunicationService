using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
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
    }
}
