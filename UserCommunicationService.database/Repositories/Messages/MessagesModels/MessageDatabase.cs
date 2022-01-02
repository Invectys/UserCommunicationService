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
            DateTime creationTimeStamp)
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
