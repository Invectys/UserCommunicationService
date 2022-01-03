using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class ChatToUser
    {
        public ChatToUser(string userId, Guid chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }


        public string UserId { get; }
        public Guid ChatId { get; }
    }
}
