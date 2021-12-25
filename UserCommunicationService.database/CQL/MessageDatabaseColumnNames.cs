using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database.CQL
{
    internal static class MessageDatabaseColumnNames
    {
        public static string IdName = "id";
        public static string FromIdName = "from_id";
        public static string ToIdName = "to_id";
        public static string ChatIdName = "chat_id";
        public static string ContentName = "content";
        public static string CreationTimeName = "creation_time";
    }
}
