using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            $"{MessageDatabaseColumnNames.CreationTimeName})";

        public static string InsertPrepareMessageQuery = $"INSERT INTO {Constants.MessagesTableName} {_messageValueBloc} VALUES (?, ?, ?, ?, ?, ?);";


        

    }
}
