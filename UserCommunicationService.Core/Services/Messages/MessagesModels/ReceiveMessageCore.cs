using Invectys.media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services.Messages.MessagesModels
{
    public class ReceiveMessageCore
    {
        public ReceiveMessageCore(Guid id, string fromId, string? toId, 
            Guid chatId, string content, DateTimeOffset creationTimeStamp, List<InvectysMedia> files, 
            string displayName, InvectysMedia displayMedia, Guid preAddedId, string sendingStatus)
        {
            Id = id;
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
            CreationTimeStamp = creationTimeStamp;
            Files = files;
            DisplayMedia = displayMedia;
            DisplayName = displayName;
            PreAddedId = preAddedId;
            SendingStatus = sendingStatus;
        }

        public Guid Id { get; }
        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public List<InvectysMedia> Files { get; }
        public DateTimeOffset CreationTimeStamp { get; }
        public string DisplayName { get; set; }
        public InvectysMedia DisplayMedia { get; set; }
        public Guid PreAddedId { get; set; }
        public string SendingStatus { get; set; }
    }
}
