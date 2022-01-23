using Invectys.media;
using UserCommunicationService.Core.Services.Messages.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class ReceiveMessage
    {
        public ReceiveMessage(Guid id, string fromId, string? toId, Guid chatId, string content, DateTime creationTimeStamp, List<InvectysMedia> files)
        {
            Id = id;
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
            CreationTimeStamp = creationTimeStamp;
            Files = files;
        }

        public ReceiveMessage(ReceiveMessageCore core) : this(
            id: core.Id, fromId: core.FromId, toId: core.ToId, chatId: core.ChatId, content: core.Content, creationTimeStamp: core.CreationTimeStamp, files: core.Files)
        {
        }

        public Guid Id { get; }
        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public List<InvectysMedia> Files { get; set; }
        public DateTimeOffset CreationTimeStamp { get; }

        
    }
}
