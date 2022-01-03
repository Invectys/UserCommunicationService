using Cassandra;
using Cassandra.Mapping;
using UserCommunicationService.database.CQL;
using UserCommunicationService.database.CQL.ChatToUser;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.database.Repositories.Chats
{
    public class ChatsRepository : Repository
    {
        public ChatsRepository(Database database) : base(database)
        {
        }


        public async Task InsertMany(List<UserToChatDatabase> rows)
        {
            var batch = new BatchStatement();

            var preparedInsertUserToChat = UserToChatDatabaseQueries.GetPreparedInsert(database.Session);
            var preparedInsertChatToUser = ChatToUserDatabaseQueries.GetPreparedInsert(database.Session);
            foreach (var row in rows)
            {
                var chatToUser = new ChatToUserDatabase(row.UserId, row.ChatId);
                batch.Add(UserToChatDatabaseQueries.BindInsertUserToChat(row, preparedInsertUserToChat));
                batch.Add(ChatToUserDatabaseQueries.BindInsertChatToUser(chatToUser, preparedInsertChatToUser));
            }
            
            await database.Session.ExecuteAsync(batch);
        }

        public IPage<UserToChatDatabase> FetchChats(int pageSize, byte[] pagingState, string userId)
        {
            var queryStr = UserToChatDatabaseQueries.GetSelectQuery(userId);
            var queryOptions = Cql.New(queryStr).WithOptions(opt => opt.SetPageSize(pageSize).SetPagingState(pagingState));
            var mapper = database.Mapper;
            IPage<UserToChatDatabase> page = mapper.FetchPage<UserToChatDatabase>(queryOptions);
            return page;
        }

        public IPage<ChatToUserDatabase> FetchChatUsers(int pageSize, byte[] pagingState, string chatId)
        {
            var queryStr = ChatToUserDatabaseQueries.GetSelectQuery(chatId);
            var queryOptions = Cql.New(queryStr).WithOptions(opt => opt.SetPageSize(pageSize).SetPagingState(pagingState));
            var mapper = database.Mapper;
            IPage<ChatToUserDatabase> page = mapper.FetchPage<ChatToUserDatabase>(queryOptions);
            return page;
        }

       
    }
}
