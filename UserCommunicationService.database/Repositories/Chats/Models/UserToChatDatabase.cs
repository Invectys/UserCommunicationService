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
            string role
            )
        {
            UserId = userId;
            ChatId = chatId;
            Banned = banned;
            ChatName = chatName;
            NotificationsEnabled = notificationsEnabled;
            Role = role;
        }


        public string UserId { get; set; }
        public Guid ChatId { get; set; }
        public bool Banned { get; set; }
        public bool NotificationsEnabled { get; set; }
        public string ChatName { get; set; }
        public string Role { get; set; }
    }
}
