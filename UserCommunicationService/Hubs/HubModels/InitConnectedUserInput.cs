namespace UserCommunicationService.Hubs.HubModels
{
    public class InitConnectedUserInput
    {
        public InitConnectedUserInput(Guid userId)
        {
            UserId = userId;
        }


        public int MaxChats { get => 1000000; }
        public Guid UserId { get; }
    }
}
