using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class FetchChatUsersOutput
    {
        public FetchChatUsersOutput(IEnumerable<ChatToUser> results, byte[] pagingState, Guid chatId)
        {
            Results = results;
            PagingState = pagingState;
            ChatId = chatId;
        }


        public IEnumerable<ChatToUser> Results { get; }
        public byte[] PagingState { get; }
        public Guid ChatId { get; }
    }
}
