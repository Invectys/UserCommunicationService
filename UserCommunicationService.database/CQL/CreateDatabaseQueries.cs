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
            $"{MessageDatabaseColumnNames.ChatIdName} uuid,{MessageDatabaseColumnNames.FromIdName} uuid, {MessageDatabaseColumnNames.ToIdName} uuid, {MessageDatabaseColumnNames.ContentName} text, {MessageDatabaseColumnNames.CreationTimeName} time, PRIMARY KEY (id, {MessageDatabaseColumnNames.CreationTimeName}) );";

        //public static string CreateMessageUDT = $"CREATE TYPE IF NOT EXISTS {Constants.MessageUDTName} {{ {MessageDatabaseColumnNames.FromIdName} uuid, {MessageDatabaseColumnNames.ToIdName} uuid, {MessageDatabaseColumnNames.ContentName} text, {MessageDatabaseColumnNames.CreationTimeName} time }};";
    }
}
