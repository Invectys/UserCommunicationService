using Invectys.media;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Hubs.ChatModels
{
    public class UserToChatOutput
    {
        public UserToChatOutput(string userId, Guid chatId, int newMessagesCount, string chatName,
            bool notificationsEnabled, bool banned, InvectysMedia avatar)
        {
            UserId = userId;
            ChatId = chatId;
            NewMessagesCount = newMessagesCount;
            ChatName = chatName;
            NotificationsEnabled = notificationsEnabled;
            Banned = banned;
            Avatar = avatar;
        }


        public string UserId { get; }
        public Guid ChatId { get; }
        public int NewMessagesCount { get; set; }
        public string ChatName { get; set; }
        public bool NotificationsEnabled { get; set; }
        public bool Banned { get; set; }
        public InvectysMedia Avatar { get; set; }

        public static UserToChatOutput FromDatabase(UserToChatDatabase database, int newMessagesCount)
        {
            return new UserToChatOutput(database.UserId, database.ChatId, 
                newMessagesCount: newMessagesCount, chatName: database.ChatName, 
                notificationsEnabled: database.NotificationsEnabled, banned: database.Banned, avatar: database.Avatar);
        }
    }
}
