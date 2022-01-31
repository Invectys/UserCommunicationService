using Invectys.media;

namespace UserCommunicationService.database.Repositories.Chats.Models
{
    public class UserToChatDatabase
    {
        // for mapping 
        // for fetching from database
        // dont use for creating instance via code!
        public UserToChatDatabase()
        {
        }

        public UserToChatDatabase(
            string userId,
            Guid chatId, 
            bool banned, 
            bool notificationsEnabled,
            string chatName,
            string role,
            InvectysMedia avatar,
            InvectysMedia background,
            int viewHeight,
            bool pinned,
            int fontSize,
            int borderRadius
            )
        {
            UserId = userId;
            ChatId = chatId;
            Banned = banned;
            ChatName = chatName;
            NotificationsEnabled = notificationsEnabled;
            Role = role;
            Avatar = avatar;
            Background = background;
            ViewHeight = viewHeight;
            Pinned = pinned;
            FontSize = fontSize;
            BorderRadius = borderRadius;
        }


        public string UserId { get; set; }
        public Guid ChatId { get; set; }
        public bool Banned { get; set; }
        public bool NotificationsEnabled { get; set; }
        public string ChatName { get; set; }
        public string Role { get; set; }
        public InvectysMedia Avatar { get; set; }
        public InvectysMedia Background { get; set; }
        public int ViewHeight { get; set; }
        public bool Pinned { get; set; }
        public int FontSize { get; set; }
        public int BorderRadius { get; set; }
    }
}
