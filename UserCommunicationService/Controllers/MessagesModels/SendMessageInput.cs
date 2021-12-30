using UserCommunicationService.Core.Services.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class SendMessageInput
    {
        public SendMessageInput(Guid fromId, Guid toId, string content, Guid? chatId = null)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
        }


        public Guid FromId { get; }
        public Guid ToId { get; }
        public Guid? ChatId { get; private set; }
        public string Content { get; }

        public SendMessageInputCore ToCoreModel(DateTime creationTime)
        {
            Guid? chatId = ChatId;
            if (chatId.HasValue == false)
            {
                chatId = new Guid();
            }

            return new SendMessageInputCore(chatId: chatId.Value, toId: ToId, fromId: FromId, content: Content, creationTime: creationTime);
        }

       
    }
}
