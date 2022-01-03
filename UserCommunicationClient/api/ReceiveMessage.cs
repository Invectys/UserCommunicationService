using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class ReceiveMessage
    {
        public ReceiveMessage(string fromId, string? toId, Guid chatId, string content)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
        }


        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
    }
}
