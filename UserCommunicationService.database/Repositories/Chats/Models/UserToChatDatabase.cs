using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database.Repositories.Chats.Models
{
    public class UserToChatDatabase
    {
        // for mapping 
        // for fetching from database
        // dont use for creating instance via code!
        public UserToChatDatabase()
        {
        }

        public UserToChatDatabase(Guid id, Guid userId, Guid chatId )
        {
            Id = id;
            UserId = userId;
            ChatId = chatId;
        }


        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
