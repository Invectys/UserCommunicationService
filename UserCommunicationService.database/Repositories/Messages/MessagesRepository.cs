using Cassandra.Mapping;
using UserCommunicationService.database.CQL;
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
            var statement = MessagesDatabaseQueries.BindInsert(database.Session, message);
            await database.Session.ExecuteAsync(statement);
        }

        public IPage<MessageDatabase> Fetch(int pageSize, byte[] pagingState, string chatId)
        {
            var rawQuery = MessagesDatabaseQueries.GetSelectByChatIdQuery(chatId);
            var queryOptions = Cql.New(rawQuery).WithOptions(opt => opt.SetPageSize(pageSize).SetPagingState(pagingState));
            var mapper = database.Mapper;
            IPage<MessageDatabase> page = mapper.FetchPage<MessageDatabase>(queryOptions);
            return page;
        }
    }
}
