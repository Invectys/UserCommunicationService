namespace UserCommunicationService.Hubs.ChatModels
{
    public class CreateDialogInput
    {
        public CreateDialogInput(Guid firstUserId, Guid secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }


        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
    }
}
