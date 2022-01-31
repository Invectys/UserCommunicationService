using Invectys.media;
using UserCommunicationService.Core.Services.Messages.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class ReceiveMessage
    {
        public ReceiveMessage(Guid id, string fromId, string? toId, 
            Guid chatId, string content, DateTimeOffset creationTimeStamp, 
            List<InvectysMedia> files, string displayName, InvectysMedia displayMedia,
            Guid preAddedId, string sendingStatus
            )
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

        public ReceiveMessage(ReceiveMessageCore core) : this(
                id: core.Id, 
                fromId: core.FromId, 
                toId: core.ToId, 
                chatId: core.ChatId, 
                content: core.Content, 
                creationTimeStamp: core.CreationTimeStamp, 
                files: core.Files, 
                displayMedia: core.DisplayMedia, 
                displayName: core.DisplayName,
                sendingStatus: core.SendingStatus, 
                preAddedId: core.PreAddedId
            )
        {
        }


        public Guid Id { get; }
        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public List<InvectysMedia> Files { get; set; }
        public DateTimeOffset CreationTimeStamp { get; }
        public string DisplayName { get; set; }
        public InvectysMedia DisplayMedia { get; set; }
        public Guid PreAddedId { get; set; }
        public string SendingStatus { get; set; }
    }
}
