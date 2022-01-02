using Cassandra.Mapping;
using UserCommunicationService.Core.Services.Messages.MessagesModels;
using UserCommunicationService.Core.Services.MessagesModels;
using UserCommunicationService.database.Repositories;
using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.Core.Services.Messages
{
    public class MessagesService : IMessagesService
    {
        public MessagesService(
            MessagesRepository repository
            )
        {
            _repository = repository;
        }


        private MessagesRepository _repository;


        public async Task SaveMessage(SendMessageInputCore input)
        {
            var sendMessageDatabase = input.ToDatabase(Guid.NewGuid());
            await _repository.SaveMessage(sendMessageDatabase);
        }

        

        public IPage<MessageDatabase> FetchMessages(FetchMessagesInputCore input)
        {
            var result = _repository.Fetch(input.PageSize, input.PagingState, input.ChatId.ToString());
            return result;
        }
    }
}
