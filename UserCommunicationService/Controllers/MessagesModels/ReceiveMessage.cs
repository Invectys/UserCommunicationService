using UserCommunicationService.Core.Services.Messages.MessagesModels;

namespace UserCommunicationService.Controllers.MessagesModels
{
    public class ReceiveMessage
    {
        public ReceiveMessage(Guid fromId, Guid toId, Guid chatId, string content)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
        }

        public ReceiveMessage(ReceiveMessageCore core) : this(fromId: core.FromId, toId: core.ToId, chatId: core.ChatId, content: core.Content)
        {
            
        }


        public Guid FromId { get; }
        public Guid ToId { get; }
        public Guid ChatId { get; }
        public string Content { get; }

        
    }
}
