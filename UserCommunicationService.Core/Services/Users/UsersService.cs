using Invectys.UsersService.Client;
using Invectys.UsersService.Client.Models;
using Newtonsoft.Json;
using UserCommunicationService.Core.Services.Users;
using UserCommunicationService.Core.Services.Users.Models;

namespace UserCommunicationService.Core.Services
{
    public class UsersService : IUsersService
    {
        public UsersService()
        {
            _usersServcieApi = new UsersServiceApi(UsersServiceLocalApi);
        }

        public const string UsersServiceLocalApi = "http://localhost:5130/";
        public const string UsersServiceProdApi = "http://194.67.104.187:5022/";

        public const string ProjectId = "tusanetworkv3";
        public const string Audience = ProjectId;
        public const string Issuer = "https://securetoken.google.com/" + ProjectId;

        private UsersServiceApi _usersServcieApi;

        public async Task<UserCore[]> FetchUsers(string[] userIds)
        {
            var input = new FetchUsersWithdIdsInput(userIds: new List<string>(userIds));
            var result = await _usersServcieApi.FetchUsersWithIds(input);
            var users = result.Users.Select(u => new UserCore(u)).ToArray();
            return users;
        }
    }
}
