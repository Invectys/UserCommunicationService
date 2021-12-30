using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class FetchChatsOutput
    {
        public FetchChatsOutput(IEnumerable<UserToChat> results, byte[] pagingState, Guid userId)
        {
            Results = results;
            PagingState = pagingState;
            UserId = userId;
        }


        public IEnumerable<UserToChat> Results { get; }
        public byte[] PagingState { get; }
        public Guid UserId { get; }
    }
}
