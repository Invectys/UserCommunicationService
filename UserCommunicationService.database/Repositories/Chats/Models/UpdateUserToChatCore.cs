using Invectys.media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database.Repositories.Chats.Models
{
    public class UpdateUserToChatCore
    {
        public UpdateUserToChatCore()
        {

        }

        public UpdateUserToChatCore(string userId, Guid chatId, string chatName, string subtitle, bool notificationsEnabled, InvectysMedia avatar)
        {
            ChatId = chatId;
            ChatName = chatName;
            Subtitle = subtitle;
            NotificationsEnabled = notificationsEnabled;
            Avatar = avatar;
            UserId = userId;
        }



        public Guid ChatId { get; set; }
        public string UserId { get; set; }
        public string ChatName { get; set; }
        public string Subtitle { get; set; }
        public bool NotificationsEnabled { get; set; }
        public InvectysMedia Avatar { get; set; }
    }
}
