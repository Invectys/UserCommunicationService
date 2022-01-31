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
            DateTimeOffset creationTimeStamp,
            List<InvectysMedia> files,
            Guid preAddedId,
            string sendingStatus
            )
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
            Id = id;
            Files = files;
            PreAddedId = preAddedId;
            SendingStatus = sendingStatus;
        }


        public Guid Id { get; set; }
        public string FromId { get; set; }
        public string? ToId { get; set; }
        public Guid ChatId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreationTimeStamp { get; set; }
        public List<InvectysMedia> Files { get; set; }
        public Guid PreAddedId { get; set; }
        public string SendingStatus { get; set; }
    }
}
