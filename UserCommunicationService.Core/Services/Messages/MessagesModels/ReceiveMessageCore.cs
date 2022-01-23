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
        public ReceiveMessageCore(Guid id, string fromId, string? toId, Guid chatId, string content, DateTime creationTimeStamp, List<InvectysMedia> files)
        {
            Id = id;
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
            CreationTimeStamp = creationTimeStamp;
            Files = files;
        }

        public Guid Id { get; }
        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public List<InvectysMedia> Files { get; }
        public DateTime CreationTimeStamp { get; }
    }
}
