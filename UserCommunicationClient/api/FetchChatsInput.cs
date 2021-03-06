using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class FetchChatsInput
    {
        public FetchChatsInput(string userId, byte[]? pagingState, int pageSize = 5)
        {
            UserId = userId;
            PageSize = pageSize;
            PagingState = pagingState;
        }


        public string UserId { get; set; }
        public int PageSize { get; set; }
        public byte[]? PagingState { get; set; }
    }
}
