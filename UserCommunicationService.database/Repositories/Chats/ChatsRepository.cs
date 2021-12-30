using Cassandra;
using Cassandra.Mapping;
using UserCommunicationService.database.CQL;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.database.Repositories.Chats
{
    public class ChatsRepository : Repository
    {
        public ChatsRepository(Database database) : base(database)
        {
        }

        public async Task Insert(UserToChatDatabase row)
        {
            var preparedInsert = database.Session.Prepare(UserToChatDatabaseQueries.InsertPreparRowQuery);
            var statement = BindInsertUserToChat(row, preparedInsert);
            await database.Session.ExecuteAsync(statement);
        }

        public async Task InsertMany(List<UserToChatDatabase> rows)
        {
            var batch = new BatchStatement();

            var preparedInsert = database.Session.Prepare(UserToChatDatabaseQueries.InsertPreparRowQuery);
            foreach (var row in rows)
            {
                batch.Add(BindInsertUserToChat(row, preparedInsert));
            }
            
            await database.Session.ExecuteAsync(batch);
        }

        public IPage<UserToChatDatabase> FetchChats(int pageSize, byte[] pagingState, string userId)
        {
            var queryStr = $"SELECT * FROM {Constants.UserToChatTableName} WHERE {UserToChatDatabaseColumnNames.UserId} = {userId}";
            var queryOptions = Cql.New(queryStr).WithOptions(opt => opt.SetPageSize(pageSize).SetPagingState(pagingState));
            var mapper = database.Mapper;
            IPage<UserToChatDatabase> page = mapper.FetchPage<UserToChatDatabase>(queryOptions);
            return page;
        }

        private BoundStatement BindInsertUserToChat(UserToChatDatabase row, PreparedStatement insert)
        {
            return insert.Bind(row.Id, row.UserId, row.ChatId);
        } 
    }
}
