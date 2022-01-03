namespace UserCommunicationService.Hubs.ChatModels
{
    public class CreateGroupChatInput
    {
        public CreateGroupChatInput(List<string> users, string chatName)
        {
            ChatName = chatName;
            Users = users;
        }


        public string ChatName { get; set; }
        public List<string> Users { get; }
    }
}
