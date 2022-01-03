namespace UserCommunicationService.Hubs.ChatModels
{
    public class AddUserToChatInput
    {
        public AddUserToChatInput(string userId, Guid chatId, string chatName)
        {
            UserId = userId;
            ChatId = chatId;
            ChatName = chatName;
        }


        public string ChatName { get; set; }
        public string UserId { get; }
        public Guid ChatId { get; }
    }
}
