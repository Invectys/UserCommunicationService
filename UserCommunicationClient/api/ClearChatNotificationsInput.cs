using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class ClearChatNotificationsInput
    {
        public ClearChatNotificationsInput(Guid chatId, Guid userId)
        {
            ChatId = chatId;
            UserId = userId;
        }


        public Guid ChatId { get; }
        public Guid UserId { get; }
    }
}
