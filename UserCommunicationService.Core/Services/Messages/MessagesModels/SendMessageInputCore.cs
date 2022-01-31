using Invectys.media;
using UserCommunicationService.Core.Services.Messages.MessagesModels;
using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.Core.Services.MessagesModels
{
    public class SendMessageInputCore
    {
        public SendMessageInputCore(string fromId, string? toId, 
            Guid chatId, string content, DateTimeOffset creationTimeStamp, 
            List<InvectysMedia> files, Guid preAddedId)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
            Files = files;
            PreAddedId = preAddedId;
        }


        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public List<InvectysMedia> Files { get; set; }
        public DateTimeOffset CreationTimeStamp { get; }
        public Guid PreAddedId { get; set; }


        public MessageDatabase ToDatabase(Guid guid, string sendingStatus)
        {
            return new MessageDatabase(
                id: guid, 
                toId: ToId, 
                fromId: FromId,
                chatId: ChatId, 
                content: Content,
                creationTimeStamp: CreationTimeStamp,
                files: Files,
                preAddedId: PreAddedId,
                sendingStatus: sendingStatus
            );
        }

        public ReceiveMessageCore ToReceiveMessageCore(Guid guid, string displayName, string sendingStatus, InvectysMedia media)
        {
            return new ReceiveMessageCore(
                id: guid, 
                chatId: ChatId, 
                toId: ToId, fromId: FromId,
                content: Content,
                creationTimeStamp: CreationTimeStamp, 
                files: Files, 
                displayName: displayName, 
                displayMedia: media,
                preAddedId: PreAddedId,
                sendingStatus: sendingStatus
            );
        }
    }
}
