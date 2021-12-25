using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class FetchMessagesOutput
    {
        public FetchMessagesOutput(IEnumerable<Message> messages, byte[] pagingState)
        {
            Messages = messages;
            PagingState = pagingState;
        }


        public IEnumerable<Message> Messages { get; }
        public byte[] PagingState { get; }
    }
}
