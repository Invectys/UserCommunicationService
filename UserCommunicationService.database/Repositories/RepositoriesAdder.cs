using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database.Repositories
{
    public static class RepositoriesAdder
    {
        public static void AddRepositories(IServiceCollection collection)
        {
            collection.AddSingleton<MessagesRepository>();
        }
    }
}
