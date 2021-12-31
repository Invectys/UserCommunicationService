using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database.Repositories.Messages.MessagesModels
{
    public class MessageDatabase
    {
        // for mapping 
        // for fetching from database
        // dont use for creating instance via code!
        public MessageDatabase()
        {
        }

        // Use it
        public MessageDatabase(
            Guid id, 
            Guid fromId,
            Guid? toId, 
            Guid chatId, 
            string content, 
            bool seen,
            DateTime creationTimeStamp)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
            Id = id;
            Seen = seen;
        }


        public Guid Id { get;  }
        public Guid FromId { get;}
        public Guid? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public bool Seen { get; set; }
        public DateTime CreationTimeStamp { get; }
    }
}
