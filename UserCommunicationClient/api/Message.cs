using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class Message
    {
        public Message(Guid id,Guid chatId, Guid fromId, Guid toId, string content, DateTime creationTime)
        {
            ChatId = chatId;
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTime = creationTime;
            Id = id;
        }


        public Guid Id { get; }
        public Guid ChatId { get; }
        public Guid FromId { get; }
        public Guid ToId { get; }
        public string Content { get; }
        public DateTime CreationTime { get; }
    }
}
