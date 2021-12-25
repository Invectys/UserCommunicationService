using UserCommunicationService.Core.Services.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class SendMessageInput
    {
        public SendMessageInput(Guid chatId, Guid fromId, Guid toId, string content)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
        }


        public Guid FromId { get; }
        public Guid ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }

        public SendMessageInputCore ToCoreModel(DateTime creationTime)
        {
            return new SendMessageInputCore(chatId: ChatId, toId: ToId, fromId: FromId, content: Content, creationTime: creationTime);
        }
    }
}
