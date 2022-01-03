namespace UserCommunicationService.Hubs.HubModels
{
    public class InitConnectedUserInput
    {
        public InitConnectedUserInput(string userId)
        {
            UserId = userId;
        }


        public int MaxChats { get => 1000000; }
        public string UserId { get; }
    }
}
