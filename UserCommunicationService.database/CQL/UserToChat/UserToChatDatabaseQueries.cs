using Cassandra;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.database.CQL
{
    public class UserToChatDatabaseQueries
    {
        public readonly static string valueBloc = $"(" +
            $"{UserToChatDatabaseColumnNames.UserId}, " +
            $"{UserToChatDatabaseColumnNames.ChatId}) ";

        public readonly static string InsertPreparRowQuery = $"INSERT INTO {Constants.UserToChatTableName} {valueBloc} VALUES (?, ?);";

        
        public static string GetSelectQuery(string userId)
        {
            var queryStr = $"SELECT * FROM {Constants.UserToChatTableName} WHERE {UserToChatDatabaseColumnNames.UserId} = {userId}";
            return queryStr;
        }

        public static PreparedStatement GetPreparedInsert(ISession session)
        {
            var statement = session.Prepare(InsertPreparRowQuery);
            return statement;
        }

        public static BoundStatement BindInsertUserToChat(UserToChatDatabase row, PreparedStatement insert)
        {
            return insert.Bind(row.UserId, row.ChatId);
        }
    }
}
