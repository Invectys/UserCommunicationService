using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using UserCommunicationService.Core.Services.Users;
using UserCommunicationService.Core.Services.Users.Models;

namespace UserCommunicationService.Core.Services
{
    public class UsersService : IUsersService
    {
        public UsersService()
        {

        }

        public const string ProjectId = "tusanetworkv3";
        public const string Audience = ProjectId;
        public const string Issuer = "https://securetoken.google.com/" + ProjectId;


        public void Initialize()
        {
            
            // load from config file
            var configFilePath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            if(!string.IsNullOrEmpty(configFilePath))
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(configFilePath)
                });
                return;
            }


            configFilePath = "volume/firebase.json";
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(configFilePath)
            });
        }

        public async Task<UserCore> FetchUser(string userId)
        {
            UserRecord record = await FirebaseAuth.DefaultInstance.GetUserAsync(userId);

            return FromRecord(record);
        }

        public async Task<UserCore[]> FetchUsers(string[] userIds)
        {
            var list = userIds.Select(u => new UidIdentifier(u)).ToArray();

            var result = await FirebaseAuth.DefaultInstance.GetUsersAsync(list)!;
            var users = result.Users;

            var mapped = users.Select(u => FromRecord(u)).ToArray();
            return mapped;
        }


        private UserCore FromRecord(UserRecord record)
        {
            return new UserCore(
                userId: record.Uid,
                privateChatName: record.DisplayName,
                messageDisplayName: record.DisplayName,
                phoneNumber: record.PhoneNumber
            );
        }
    }
}
