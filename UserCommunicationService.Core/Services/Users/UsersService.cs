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

            //var type = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_TYPE");
            //var projectId = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_PROJECT_ID");
            //var privateKeyId = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_PRIVATE_KEY_ID");
            //var privateKey = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_PRIVATE_KEY");
            //var clientEmail = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_CLIENT_EMAIL");
            //var clientId = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_CLIENT_ID");
            //var authUri = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_AUTH_URI");
            //var tokenUri = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_TOKEN_URI");
            //var authProviderX509CertUrl = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_AUTH_PROVIDER_CERT_URL");
            //var clientX509CertUrl = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_CLIENT_CERT_URL");

            //var options = new GoogleCredentialsOptions() { 
            //    Type = type,
            //    ProjectId = projectId,
            //    PrivateKey = privateKey,
            //    PrivateKeyId = privateKeyId,
            //    ClientEmail = clientEmail,
            //    ClientId = clientId,
            //    AuthUri = authUri,
            //    TokenUri = tokenUri,
            //    AuthProviderX509CertUrl = authProviderX509CertUrl,
            //    ClientX509RertUrl = clientX509CertUrl,
            //};

            //var json = JsonConvert.SerializeObject(options);

            //FirebaseApp.Create(new AppOptions()
            //{
            //    Credential = GoogleCredential.FromJson(json),
            //});
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

        protected class GoogleCredentialsOptions
        {
            [JsonProperty(PropertyName = "type")]
            public string Type { get; set; }

            [JsonProperty(PropertyName = "project_id")]
            public string ProjectId { get; set; }

            [JsonProperty(PropertyName = "private_key_id")]
            public string PrivateKeyId { get; set; }

            [JsonProperty(PropertyName = "private_key")]
            public string PrivateKey { get; set; }

            [JsonProperty(PropertyName = "client_email")]
            public string ClientEmail { get; set; }

            [JsonProperty(PropertyName = "client_id")]
            public string ClientId { get; set; }

            [JsonProperty(PropertyName = "auth_uri")]
            public string AuthUri { get; set; }

            [JsonProperty(PropertyName = "TokenUri")]
            public string TokenUri { get; set; }

            [JsonProperty(PropertyName = "auth_provider_x509_cert_url")]
            public string AuthProviderX509CertUrl { get; set; }

            [JsonProperty(PropertyName = "client_x509_cert_url")]
            public string ClientX509RertUrl { get; set; }
        }
    }
}
