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
            Guid fromId,
            Guid? toId,
            Guid chatId,
            string content,
            bool seen,
            DateTime creationTimeStamp
        )
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
            Id = id;
            Seen = seen;
        }


        public Guid Id { get; }
        public Guid FromId { get; }
        public Guid? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public bool Seen { get; set; }
        public DateTime CreationTimeStamp { get; }
    }
}
