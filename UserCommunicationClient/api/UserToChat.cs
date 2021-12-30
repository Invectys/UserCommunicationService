using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class UserToChat
    {
        public UserToChat(Guid id, Guid userId, Guid chatId)
        {
            Id = id;
            UserId = userId;
            ChatId = chatId;
        }


        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
