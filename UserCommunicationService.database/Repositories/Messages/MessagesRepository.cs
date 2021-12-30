using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunicationService.database.CQL;
using UserCommunicationService.database.Repositories.Messages;
using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.database.Repositories
{
    public class MessagesRepository : Repository
    {
        public MessagesRepository(Database database) : base(database)
        {
        }


        public async Task SaveMessage(MessageDatabase message)
        {
            var preparedInsert = database.Session.Prepare(MessagesDatabaseQueries.InsertPrepareMessageQuery);
            var statement = preparedInsert.Bind(message.Id, message.ChatId, message.FromId, message.ToId, message.Content, message.CreationTimeStamp);
            await database.Session.ExecuteAsync(statement);
        }

        public IPage<MessageDatabase> Fetch(int pageSize, byte[] pagingState, string chatId)
        {
            var queryStr = $"SELECT * FROM {Constants.MessagesTableName} WHERE {MessageDatabaseColumnNames.ChatIdName} = {chatId}";
          
            var queryOptions = Cql.New(queryStr).WithOptions(opt => opt.SetPageSize(pageSize).SetPagingState(pagingState));
            var mapper = database.Mapper;
            IPage<MessageDatabase> page = mapper.FetchPage<MessageDatabase>(queryOptions);
            return page;
        }

        

    }
}
