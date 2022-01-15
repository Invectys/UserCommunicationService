using Invectys.media;
using UserCommunicationService.Core.Services.Chats.ChatsModels;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Hubs.ChatModels
{
    public class UpdateUserToChat
    {
        public UpdateUserToChat()
        {

        }


        public Guid ChatId { get; set; }
        public string ChatName { get; set; }
        public string Subtitle { get; set; }
        public bool NotificationsEnabled { get; set; }
        public InvectysMedia Avatar { get; set; }


        public UpdateUserToChatCore ToCore(string userId)
        {
            return new UpdateUserToChatCore(userId: userId, chatId: ChatId, chatName: ChatName, 
                subtitle: Subtitle, notificationsEnabled: NotificationsEnabled, avatar: Avatar);
        }
    }
}
