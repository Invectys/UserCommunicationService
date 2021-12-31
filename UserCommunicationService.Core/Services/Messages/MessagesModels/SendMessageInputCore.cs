using UserCommunicationService.Core.Services.Messages.MessagesModels;
using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.Core.Services.MessagesModels
{
    public class SendMessageInputCore
    {
        public SendMessageInputCore(Guid fromId, Guid? toId, Guid chatId, string content, DateTime creationTimeStamp)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            CreationTimeStamp = creationTimeStamp;
            ChatId = chatId;
        }


        public Guid FromId { get; }
        public Guid? ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }
        public DateTime CreationTimeStamp { get; }


        public MessageDatabase ToDatabase(Guid guid)
        {
            return new MessageDatabase(
                id: guid, 
                toId: ToId, 
                fromId: FromId,
                chatId: ChatId, 
                content: Content,
                seen: false,
                creationTimeStamp: CreationTimeStamp
            );
        }

        public ReceiveMessageCore ToReceiveMessageCore()
        {
            return new ReceiveMessageCore(chatId: ChatId, toId: ToId, fromId: FromId, content: Content);
        }
    }
}
