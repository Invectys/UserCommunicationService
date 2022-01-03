using Cassandra.Mapping;
using System;
using UserCommunicationService.Core.Services.Messages.MessagesModels;
using UserCommunicationService.Core.Services.MessagesModels;
using UserCommunicationService.database.Repositories.Messages.MessagesModels;

namespace UserCommunicationService.Core.Services.Messages
{
    public interface IMessagesService
    {
        Task<Guid> SaveMessage(SendMessageInputCore input);
        IPage<MessageDatabase> FetchMessages(FetchMessagesInputCore input);
       
    }
}
