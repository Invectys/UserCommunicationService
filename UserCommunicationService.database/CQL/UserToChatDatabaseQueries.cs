using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database.CQL
{
    public class UserToChatDatabaseQueries
    {
        private static string valueBloc = $"(" +
            $"{UserToChatDatabaseColumnNames.IdName}, " +
            $"{UserToChatDatabaseColumnNames.UserId}, " +
            $"{UserToChatDatabaseColumnNames.ChatId}) ";

        public static string InsertPreparRowQuery = $"INSERT INTO {Constants.UserToChatTableName} {valueBloc} VALUES (?, ?, ?);";
    }
}
