using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class UserToChat
    {
        public UserToChat(
            string userId,
            Guid chatId,
            bool banned,
            bool notificationsEnabled,
            string chatName,
            string role,
            int newMessagesCount
            )
        {
            UserId = userId;
            ChatId = chatId;
            Banned = banned;
            ChatName = chatName;
            NotificationsEnabled = notificationsEnabled;
            Role = role;
            NewMessagesCount = newMessagesCount;
        }


        public string UserId { get; set; }
        public Guid ChatId { get; set; }
        public bool Banned { get; set; }
        public bool NotificationsEnabled { get; set; }
        public string ChatName { get; set; }
        public string Role { get; set; }
        public int NewMessagesCount { get; set; }
    }
}
