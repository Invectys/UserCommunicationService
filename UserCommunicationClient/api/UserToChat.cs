using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class UserToChat
    {
        public UserToChat(Guid id, Guid userId, Guid chatId, int newMessagesCount)
        {
            Id = id;
            UserId = userId;
            ChatId = chatId;
            NewMessagesCount = newMessagesCount;
        }


        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ChatId { get; }
        public int NewMessagesCount { get; }
    }
}
