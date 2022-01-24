using Invectys.media;
using Invectys.UsersService.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services.Users.Models
{
    public class UserCore
    {
        public UserCore(string privateChatName, string messageDisplayName, string phoneNumber, string userId)
        {
            PrivateChatNameWithThisUser = privateChatName;
            MessageDisplayName = messageDisplayName;
            PhoneNumber = phoneNumber;
            UserId = userId;
        }

        public UserCore(User fromUsersServiceUser)
        {
            PrivateChatNameWithThisUser = fromUsersServiceUser.Nickname;
            MessageDisplayName = fromUsersServiceUser.Nickname;
            PhoneNumber = "hiden";
            UserId = fromUsersServiceUser.Id;
            Avatar = fromUsersServiceUser.Avatar.Last();
        }


        public string UserId { get; }
        public string PrivateChatNameWithThisUser { get; }
        public string MessageDisplayName { get; }
        public string PhoneNumber { get; }
        public InvectysMedia Avatar { get; set; }
    }
}
