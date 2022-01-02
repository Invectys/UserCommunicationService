﻿using System;
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
            $"{MessageDatabaseColumnNames.ChatIdName} uuid,{MessageDatabaseColumnNames.FromIdName} uuid, {MessageDatabaseColumnNames.ToIdName} uuid, {MessageDatabaseColumnNames.ContentName} text, {MessageDatabaseColumnNames.CreationTimestampName} timestamp, PRIMARY KEY ({MessageDatabaseColumnNames.ChatIdName}, {MessageDatabaseColumnNames.CreationTimestampName}) ) WITH CLUSTERING ORDER BY ({MessageDatabaseColumnNames.CreationTimestampName} DESC);";




        public static string CreateUserToChatTableCQL = $"CREATE TABLE IF NOT EXISTS {Constants.UserToChatTableName} (" +
            $"{UserToChatDatabaseColumnNames.UserId} uuid, {UserToChatDatabaseColumnNames.ChatId} uuid, PRIMARY KEY ( {UserToChatDatabaseColumnNames.UserId}, {UserToChatDatabaseColumnNames.ChatId}) ) with comment = 'get all chats of user';";


        public static string CreateChatToUserTableCQL = $"CREATE TABLE IF NOT EXISTS {Constants.ChatToUserTableName} (" +
            $"{ChatToUserDatabaseColumnNames.UserId} uuid, {ChatToUserDatabaseColumnNames.ChatId} uuid, PRIMARY KEY ( {ChatToUserDatabaseColumnNames.ChatId}, {ChatToUserDatabaseColumnNames.UserId}) ) with comment = 'get all users of chat';";

        //public static string CreateMessageUDT = $"CREATE TYPE IF NOT EXISTS {Constants.MessageUDTName} {{ {MessageDatabaseColumnNames.FromIdName} uuid, {MessageDatabaseColumnNames.ToIdName} uuid, {MessageDatabaseColumnNames.ContentName} text, {MessageDatabaseColumnNames.CreationTimeName} time }};";
    }
}
