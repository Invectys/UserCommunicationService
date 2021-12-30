using UserCommunicationService.Core.Services.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class SendMessageInput
    {
        public SendMessageInput(Guid fromId, Guid? toId, Guid chatId, string content)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
        }


        public Guid FromId { get; }
        public Guid? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }

        public SendMessageInputCore ToCoreModel(DateTime creationTimeStamp)
        {
            return new SendMessageInputCore(chatId: ChatId, toId: ToId, fromId: FromId, content: Content, creationTimeStamp: creationTimeStamp);
        }
    }
}
