using Cassandra;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.database.CQL
{
    public class UserToChatDatabaseQueries
    {
        public readonly static string valueBloc = $"(" +
            $"{UserToChatDatabaseColumnNames.UserId}, " +
            $"{UserToChatDatabaseColumnNames.Banned}, " +
            $"{UserToChatDatabaseColumnNames.NotificationsEnabled}, " +
            $"{UserToChatDatabaseColumnNames.ChatName}, " +
            $"{UserToChatDatabaseColumnNames.Role}, " +
            $"{UserToChatDatabaseColumnNames.Avatar}, " +
            $"{UserToChatDatabaseColumnNames.Background}, " +
            $"{UserToChatDatabaseColumnNames.Pinned}, " +
            $"{UserToChatDatabaseColumnNames.ViewHeight}, " +
            $"{UserToChatDatabaseColumnNames.FontSize}, " +
            $"{UserToChatDatabaseColumnNames.BorderRadius}, " +
            $"{UserToChatDatabaseColumnNames.ChatId}) ";

        public readonly static string InsertPreparRowQuery = $"INSERT INTO {Constants.UserToChatTableName} {valueBloc} VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        public static string GetUpdateUserToChatByUser(string userId, string chatId)
        {
            return $"UPDATE {Constants.UserToChatTableName} SET {UserToChatDatabaseColumnNames.NotificationsEnabled}=?, {UserToChatDatabaseColumnNames.ChatName}=?, {UserToChatDatabaseColumnNames.Avatar}=? WHERE {UserToChatDatabaseColumnNames.UserId}='{userId}' and {UserToChatDatabaseColumnNames.ChatId}={chatId};";
        }

        public static string GetSelectQuery(string userId)
        {
            var queryStr = $"SELECT * FROM {Constants.UserToChatTableName} WHERE {UserToChatDatabaseColumnNames.UserId} = '{userId}'";
            return queryStr;
        }

        public static PreparedStatement GetPreparedInsert(ISession session)
        {
            var statement = session.Prepare(InsertPreparRowQuery);
            return statement;
        }

        public static BoundStatement BindInsertUserToChat(UserToChatDatabase row, PreparedStatement insert)
        {
            return insert.Bind(
                row.UserId, 
                row.Banned, 
                row.NotificationsEnabled,
                row.ChatName, 
                row.Role, 
                row.Avatar,
                row.Background, 
                row.Pinned, 
                row.ViewHeight,
                row.FontSize,
                row.BorderRadius,
                row.ChatId
            );
        }
    }
}
