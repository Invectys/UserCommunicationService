namespace UserCommunicationService.Hubs.ChatModels
{
    public class AddUserToChatInput
    {
        public AddUserToChatInput(Guid userId, Guid chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }


        public Guid UserId { get; }
        public Guid ChatId { get; }
    }
}
