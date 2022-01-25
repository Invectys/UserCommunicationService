using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class Message
    {
        public Message(
            Guid id,
            string fromId,
            string? toId,
            Guid chatId,
            string content,
            DateTimeOffset creationTimeStamp
        )
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
            Id = id;
        }


        public Guid Id { get; }
        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public DateTimeOffset CreationTimeStamp { get; }
    }
}
