namespace UserCommunicationService.Hubs.ChatModels
{
    public class ByMeCreatedDialogWithUser
    {
        public ByMeCreatedDialogWithUser()
        {

        }

        public ByMeCreatedDialogWithUser(string userId, Guid chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }

        public string UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
