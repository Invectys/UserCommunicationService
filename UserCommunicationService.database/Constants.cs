using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database
{
    internal static class Constants
    {
        public const string KeyspaceName = "user_communication";
        public const string MessagesTableName = "messages";
        public const string UserToChatTableName = "user_to_chat";
        public const string MessageUDTName = "message";
    }
}
