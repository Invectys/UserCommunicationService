using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Hubs.ChatModels
{
    public class UserToChatOutput
    {
        public UserToChatOutput(string userId, Guid chatId, int newMessagesCount)
        {
            UserId = userId;
            ChatId = chatId;
            NewMessagesCount = newMessagesCount;
        }


        public string UserId { get; }
        public Guid ChatId { get; }
        public int NewMessagesCount { get; set; }


        public static UserToChatOutput FromDatabase(UserToChatDatabase database, int newMessagesCount)
        {
            return new UserToChatOutput(database.UserId, database.ChatId, newMessagesCount);
        }
    }
}
