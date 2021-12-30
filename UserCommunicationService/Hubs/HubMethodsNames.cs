using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Hubs
{
    internal class HubMethodsNames
    {
        public static string NewMessageName = "NewMessage";
        public static string FetchingMessagesHistory = "FetchingMessagesHistory";
        public static string FetchingChats = "FetchingChats";
    }
}
