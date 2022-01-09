namespace UserCommunicationService.Hubs.ChatModels
{
    public class CreateDialogInput
    {
        public CreateDialogInput(string userId)
        {
            UserId = userId;
        }


        public string UserId { get; set; }
    }
}
