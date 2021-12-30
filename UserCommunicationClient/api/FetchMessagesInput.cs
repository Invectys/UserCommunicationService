using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class FetchMessagesInput
    {
        public FetchMessagesInput(int pageSize, byte[]? pagingState, Guid chatId)
        {
            PageSize = pageSize;
            ChatId = chatId;
            PagingState = pagingState;
        }


        public int PageSize { get; }
        public byte[]? PagingState { get; }
        public Guid ChatId { get; }
    }
}
