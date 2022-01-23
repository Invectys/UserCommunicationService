using Invectys.media;
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
            string fromId,
            string? toId, 
            Guid chatId, 
            string content,
            DateTime creationTimeStamp,
            List<InvectysMedia> files
            )
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
            Id = id;
            Files = files;
        }


        public Guid Id { get; set; }
        public string FromId { get; set; }
        public string? ToId { get; set; }
        public Guid ChatId { get; set; }
        public string Content { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public List<InvectysMedia> Files { get; set; }
    }
}
