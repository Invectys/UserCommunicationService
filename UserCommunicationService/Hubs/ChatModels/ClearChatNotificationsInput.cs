namespace UserCommunicationService.Hubs.ChatModels
{
    public class ClearChatNotificationsInput
    {
        public ClearChatNotificationsInput(Guid chatId, Guid userId)
        {
            ChatId = chatId;
            UserId = userId;
        }


        public Guid ChatId { get; }
        public Guid UserId { get; }
    }
}
