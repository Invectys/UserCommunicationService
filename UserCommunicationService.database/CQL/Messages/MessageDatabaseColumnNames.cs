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
        public static string FromIdName = "fromid";
        public static string ToIdName = "toid";
        public static string ChatIdName = "chatid";
        public static string ContentName = "content";
        public static string CreationTimestampName = "creationtimestamp";
        public static string FilesName = "files";
    }
}
