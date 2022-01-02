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

        public UserToChatDatabase(Guid userId, Guid chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }


        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
