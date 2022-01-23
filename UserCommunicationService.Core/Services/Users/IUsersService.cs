using Invectys.UsersService.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunicationService.Core.Services.Users.Models;

namespace UserCommunicationService.Core.Services.Users
{
    public interface IUsersService
    {
        UsersServiceApi UsersServiceApi { get; set;  }
        Task<UserCore[]> FetchUsers(string[] userIds);
    }
}
