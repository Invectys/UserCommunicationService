using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services.Messages.MessagesModels
{
    public class ReceiveMessageCore
    {
        public ReceiveMessageCore(Guid fromId, Guid toId, Guid chatId, string content)
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

    }
}
