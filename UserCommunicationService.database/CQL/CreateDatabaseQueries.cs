using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database.CQL
{
    internal class CreateDatabaseQueries
    {
        public static string CreateKeyspaceCQL = $"CREATE KEYSPACE IF NOT EXISTS {Constants.KeyspaceName} WITH replication = {{'class':'SimpleStrategy', 'replication_factor':'1'}};";



        public static string CreateMessagesTableCQL = $"CREATE TABLE IF NOT EXISTS {Constants.MessagesTableName} ({MessageDatabaseColumnNames.IdName} uuid, " +
            $"{MessageDatabaseColumnNames.ChatIdName} uuid,{MessageDatabaseColumnNames.FromIdName} uuid, {MessageDatabaseColumnNames.ToIdName} uuid, {MessageDatabaseColumnNames.ContentName} text, {MessageDatabaseColumnNames.SeenName} boolean, {MessageDatabaseColumnNames.CreationTimestampName} timestamp, PRIMARY KEY ({MessageDatabaseColumnNames.ChatIdName}, {MessageDatabaseColumnNames.CreationTimestampName}) ) WITH CLUSTERING ORDER BY ({MessageDatabaseColumnNames.CreationTimestampName} DESC);";




        public static string CreateUserToChatTableCQL = $"CREATE TABLE IF NOT EXISTS {Constants.UserToChatTableName} ({UserToChatDatabaseColumnNames.IdName} uuid, " +
            $"{UserToChatDatabaseColumnNames.UserId} uuid, {UserToChatDatabaseColumnNames.ChatId} uuid, PRIMARY KEY ( {UserToChatDatabaseColumnNames.UserId}, {UserToChatDatabaseColumnNames.ChatId}) );";

        //public static string CreateMessageUDT = $"CREATE TYPE IF NOT EXISTS {Constants.MessageUDTName} {{ {MessageDatabaseColumnNames.FromIdName} uuid, {MessageDatabaseColumnNames.ToIdName} uuid, {MessageDatabaseColumnNames.ContentName} text, {MessageDatabaseColumnNames.CreationTimeName} time }};";
    }
}
