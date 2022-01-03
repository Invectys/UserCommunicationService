using Cassandra.Mapping;
using StackExchange.Redis;
using UserCommunicationService.Core.Services.Chats.ChatsModels;
using UserCommunicationService.database.Repositories.Chats;
using UserCommunicationService.database.Repositories.Chats.Models;

namespace UserCommunicationService.Core.Services.Chats
{
    public class ChatsService : IChatsService
    {
        public ChatsService(
            ChatsRepository chatsRepository,
            RedisService redis
            )
        {
            _chatsRepository = chatsRepository;
            _redis = redis;
        }


        private ChatsRepository _chatsRepository;
        private RedisService _redis;


        public async Task AddUsersToChat(List<UserToChatDatabase> row)
        {
            await _chatsRepository.InsertMany(row);
        }

        public IPage<ChatToUserDatabase> FetchChatUsers(FetchChatUsersInputCore input)
        {
            var result = _chatsRepository.FetchChatUsers(pageSize: input.PageSize, pagingState: input.PagingState, chatId: input.ChatId.ToString());
            return result;
        }

        public IPage<UserToChatDatabase> FetchChats(FetchChatsInputCore input)
        {
            var result = _chatsRepository.FetchChats(pageSize: input.PageSize, pagingState: input.PagingState, userId: input.UserId.ToString());
            return result;
        }

        public async Task AddToNotificationCount(int currentsCount, Guid chatId, string userId)
        {
            var key = GetNewMessagesCountKey(chatId, userId);
            await _redis.Database.StringIncrementAsync(key, currentsCount);
        }

        public async Task IncrementNotificationsCounter(Guid chatId, string senderId)
        {
            var tran = _redis.Database.CreateTransaction();
            var allUsers = FetchChatUsers(new FetchChatUsersInputCore(chatId, 1000000, null));
            foreach (var row in allUsers)
            {
                if(row.UserId == senderId)
                {
                    continue;
                }

                tran.StringIncrementAsync(GetNewMessagesCountKey(chatId, row.UserId), 1);
            }

            await tran.ExecuteAsync();
        }

        public async Task<int[]> GetChatsNewMessagesCount(IEnumerable<UserToChatDatabase> chats)
        {
            var keys = chats.Select(c => new RedisKey(GetNewMessagesCountKey(c.ChatId, c.UserId))).ToArray();

            var values = await _redis.Database.StringGetAsync(keys);
            var messagesCounts = values.Select(val =>
            {
                if(!val.IsNull)
                {
                    val.TryParse(out int messages);
                    return messages;
                }
                return 0;
            });

            return messagesCounts.ToArray();
        }

        public async Task<int> GetChatNewMessagesCount(Guid chatId, string userId)
        {
            var key = GetNewMessagesCountKey(chatId, userId);
            var val = await _redis.Database.StringGetAsync(key);
            if (!val.IsNull)
            {
                val.TryParse(out int messages);
                return messages;
            }
            return 0;
        }

        public async Task ClearChatNotifications(Guid chatId, string userId)
        {
            var key = GetNewMessagesCountKey(chatId, userId);
            await _redis.Database.StringSetAsync(key, "0");
        }


        private string GetNewMessagesCountKey(Guid chatId, string userId)
        {
            var key = "NEW_MESSAGES_" + chatId.ToString() + "_USER_" + userId.ToString();
            return key;
        }
    }
}
