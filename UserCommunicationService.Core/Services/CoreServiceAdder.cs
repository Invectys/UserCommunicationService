using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunicationService.Core.Services.Messages;
using UserCommunicationService.database;

namespace UserCommunicationService.Core.Services
{
    public class CoreServiceAdder
    {
        public static void AddCoreServices(IServiceCollection collection)
        {
            collection.AddSingleton(new DatabaseBuilder().BuildDatabase());
            collection.AddSingleton<IMessagesService, MessagesService>();

        }
    }
}
