using Cassandra;
using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.database.CQL
{
    internal static class MessagesDatabaseQueries
    {
        private static string _messageValueBloc = $"(" +
            $"{MessageDatabaseColumnNames.IdName}, " +
            $"{MessageDatabaseColumnNames.ChatIdName}, " +
            $"{MessageDatabaseColumnNames.FromIdName}, " +
            $"{MessageDatabaseColumnNames.ToIdName}, " +
            $"{MessageDatabaseColumnNames.ContentName}, " +
            $"{MessageDatabaseColumnNames.CreationTimestampName})";

        public readonly static string InsertPrepareMessageQuery = $"INSERT INTO {Constants.MessagesTableName} {_messageValueBloc} VALUES (?, ?, ?, ?, ?, ?);";

        public readonly static string SelectFromChat = $"SELECT * FROM {Constants.MessagesTableName} WHERE {MessageDatabaseColumnNames.ChatIdName} = ?";

        public static BoundStatement BindInsert(ISession session, MessageDatabase message)
        {
            var preparedInsert = session.Prepare(InsertPrepareMessageQuery);
            var statement = preparedInsert.Bind(message.Id, message.ChatId, message.FromId, message.ToId, message.Content, message.CreationTimeStamp);
            return statement;
        }

        public static string GetSelectByChatIdQuery(string chatId)
        {
            var result = SelectFromChat.Replace("?", chatId);
            return result;
        }
    }
}
