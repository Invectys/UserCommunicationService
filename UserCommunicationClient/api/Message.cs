using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class Message
    {
        public Message(Guid id, Guid fromId, Guid? toId, Guid chatId, string content, DateTime creationTimeStamp)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
            Id = id;
        }


        public Guid Id { get; set; }
        public Guid FromId { get; set; }
        public Guid? ToId { get; set; }
        public Guid ChatId { get; set; }
        public string Content { get; set; }
        public DateTime CreationTimeStamp { get; set; }
    }
}
