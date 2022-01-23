using Invectys.media;
using UserCommunicationService.Core.Services.Messages.MessagesModels;
using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.Core.Services.MessagesModels
{
    public class SendMessageInputCore
    {
        public SendMessageInputCore(string fromId, string? toId, Guid chatId, string content, DateTime creationTimeStamp, List<InvectysMedia> files)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
            Files = files;
        }


        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public List<InvectysMedia> Files { get; set; }
        public DateTime CreationTimeStamp { get; }


        public MessageDatabase ToDatabase(Guid guid)
        {
            return new MessageDatabase(
                id: guid, 
                toId: ToId, 
                fromId: FromId,
                chatId: ChatId, 
                content: Content,
                creationTimeStamp: CreationTimeStamp,
                files: Files
            );
        }

        public ReceiveMessageCore ToReceiveMessageCore(Guid guid, string displayName, InvectysMedia media)
        {
            return new ReceiveMessageCore(id: guid, 
                chatId: ChatId, toId: ToId, fromId: FromId,
                content: Content, creationTimeStamp: CreationTimeStamp, files: Files, displayName: displayName, displayMedia: media);
        }
    }
}
