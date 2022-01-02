namespace UserCommunicationService.Hubs.ChatModels
{
    public class UserToChatOutput
    {
        public UserToChatOutput(Guid userId, Guid chatId, int newMessagesCount)
        {
            UserId = userId;
            ChatId = chatId;
            NewMessagesCount = newMessagesCount;
        }


        public Guid UserId { get; }
        public Guid ChatId { get; }
        public int NewMessagesCount { get; set; }
    }
}
