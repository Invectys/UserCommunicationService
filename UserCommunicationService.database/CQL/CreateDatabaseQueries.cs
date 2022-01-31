using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunicationService.database.CQL.ChatToUser;

namespace UserCommunicationService.database.CQL
{
    internal class CreateDatabaseQueries
    {
        public static string CreateKeyspaceCQL = $"CREATE KEYSPACE IF NOT EXISTS {Constants.KeyspaceName} WITH replication = {{'class':'SimpleStrategy', 'replication_factor':'1'}};";



        public static string CreateMessagesTableCQL = $"CREATE TABLE IF NOT EXISTS {Constants.MessagesTableName} ({MessageDatabaseColumnNames.IdName} uuid, " +
            $"{MessageDatabaseColumnNames.ChatIdName} uuid," +
            $"{MessageDatabaseColumnNames.FromIdName} varchar, " +
            $"{MessageDatabaseColumnNames.ToIdName} varchar, " +
            $"{MessageDatabaseColumnNames.ContentName} text, " +
            $"{MessageDatabaseColumnNames.FilesName} list<frozen<invectysmedia>>, " +
            $"{MessageDatabaseColumnNames.PreAddedIdName} uuid, " +
            $"{MessageDatabaseColumnNames.SendingStatusName} varchar, " +
            $"{MessageDatabaseColumnNames.CreationTimestampName} timestamp, PRIMARY KEY ({MessageDatabaseColumnNames.ChatIdName}, {MessageDatabaseColumnNames.CreationTimestampName}) ) WITH CLUSTERING ORDER BY ({MessageDatabaseColumnNames.CreationTimestampName} DESC);";


        public const string CreateInvectysMediaUserDefinedType = $"CREATE TYPE IF NOT EXISTS invectysmedia (isasset boolean, mediaid varchar, type varchar, tag varchar, creationtime timestamp, croptop float, cropbottom float, cropleft float, cropright float);";


        public static string CreateUserToChatTableCQL = $"CREATE TABLE IF NOT EXISTS {Constants.UserToChatTableName} (" +
            $"{UserToChatDatabaseColumnNames.UserId} varchar, " +
            $"{UserToChatDatabaseColumnNames.Banned} boolean, " +
            $"{UserToChatDatabaseColumnNames.NotificationsEnabled} boolean, " +
            $"{UserToChatDatabaseColumnNames.ChatName} varchar, " +
            $"{UserToChatDatabaseColumnNames.Role} varchar, " +
            $"{UserToChatDatabaseColumnNames.Avatar} invectysmedia," +
            $"{UserToChatDatabaseColumnNames.Background} invectysmedia, " +
            $"{UserToChatDatabaseColumnNames.Pinned} boolean, " +
            $"{UserToChatDatabaseColumnNames.ViewHeight} int, " +
            $"{UserToChatDatabaseColumnNames.FontSize} int, " +
            $"{UserToChatDatabaseColumnNames.BorderRadius} int, " +
            $"{UserToChatDatabaseColumnNames.ChatId} uuid, PRIMARY KEY ( {UserToChatDatabaseColumnNames.UserId}, {UserToChatDatabaseColumnNames.ChatId}) ) with comment = 'get all chats of user';";


        public static string CreateChatToUserTableCQL = $"CREATE TABLE IF NOT EXISTS {Constants.ChatToUserTableName} (" +
            $"{ChatToUserDatabaseColumnNames.UserId} varchar, {ChatToUserDatabaseColumnNames.ChatId} uuid, PRIMARY KEY ( {ChatToUserDatabaseColumnNames.ChatId}, {ChatToUserDatabaseColumnNames.UserId}) ) with comment = 'get all users of chat';";

    }
}
