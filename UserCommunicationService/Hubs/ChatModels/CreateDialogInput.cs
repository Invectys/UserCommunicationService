namespace UserCommunicationService.Hubs.ChatModels
{
    public class CreateDialogInput
    {
        public CreateDialogInput(string firstUserId, string secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }


        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
    }
}
