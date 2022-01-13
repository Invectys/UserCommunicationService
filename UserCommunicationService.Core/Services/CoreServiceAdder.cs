using Microsoft.Extensions.DependencyInjection;
using UserCommunicationService.Core.Services.Chats;
using UserCommunicationService.Core.Services.Messages;
using UserCommunicationService.Core.Services.Users;
using UserCommunicationService.database;

namespace UserCommunicationService.Core.Services
{
    public class CoreServiceAdder
    {
        public static void AddCoreServices(IServiceCollection collection)
        {
            collection.AddSingleton(new DatabaseBuilder().BuildDatabase());
            collection.AddSingleton(new RedisBuilder().BuildRedis());

            collection.AddSingleton<IUsersService, UsersService>();

            collection.AddSingleton<IMessagesService, MessagesService>();
            collection.AddSingleton<IChatsService, ChatsService>();
        }
    }
}
