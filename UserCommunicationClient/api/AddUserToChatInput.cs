using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class AddUserToChatInput
    {
        public AddUserToChatInput(Guid userId, Guid chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }


        public Guid UserId { get; }
        public Guid ChatId { get; }
    }
}
