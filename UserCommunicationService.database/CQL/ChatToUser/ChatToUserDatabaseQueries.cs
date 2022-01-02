using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.database.CQL.ChatToUser
{
    public static class ChatToUserDatabaseQueries
    {
        public readonly static string valueBloc = $"(" +
           $"{ChatToUserDatabaseColumnNames.UserId}, " +
           $"{ChatToUserDatabaseColumnNames.ChatId}) ";

        public readonly static string InsertPreparRowQuery = $"INSERT INTO {Constants.ChatToUserTableName} {valueBloc} VALUES (?, ?);";

        public static string GetSelectQuery(string chatId)
        {
            var queryStr = $"SELECT * FROM {Constants.ChatToUserTableName} WHERE {UserToChatDatabaseColumnNames.ChatId} = {chatId}";
            return queryStr;
        }

        public static PreparedStatement GetPreparedInsert(ISession session)
        {
            var statement = session.Prepare(InsertPreparRowQuery);
            return statement;
        }

        public static BoundStatement BindInsertChatToUser(UserToChatDatabase row, PreparedStatement insert)
        {
            return insert.Bind(row.UserId, row.ChatId);
        }
    }
}
