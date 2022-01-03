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


        public string UserId { get; }
        public string PrivateChatNameWithThisUser { get; }
        public string MessageDisplayName { get; }
        public string PhoneNumber { get; }
    }
}
