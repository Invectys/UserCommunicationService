namespace UserCommunicationService.Hubs.ChatModels
{
    public class ClearChatNotificationsInput
    {
        public ClearChatNotificationsInput(Guid chatId, string userId)
        {
            ChatId = chatId;
            UserId = userId;
        }


        public Guid ChatId { get; }
        public string UserId { get; }
    }
}
