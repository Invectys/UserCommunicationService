using Invectys.media;
using UserCommunicationService.Core.Services.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class SendMessageInput
    {
        public SendMessageInput(string fromId, string? toId, Guid chatId, string content, List<InvectysMedia> files)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
            Files = files;
        }


        public string FromId { get; }
        public string? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public List<InvectysMedia> Files { get; set; }

        public SendMessageInputCore ToCoreModel(DateTimeOffset creationTimeStamp)
        {
            return new SendMessageInputCore(chatId: ChatId, toId: ToId, fromId: FromId, content: Content, creationTimeStamp: creationTimeStamp, files: Files);
        }
    }
}
