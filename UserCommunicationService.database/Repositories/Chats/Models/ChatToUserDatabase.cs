using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.database.Repositories.Chats.Models
{
    public class ChatToUserDatabase
    {
        // for mapping 
        // for fetching from database
        // dont use for creating instance via code!
        public ChatToUserDatabase()
        {
        }

        public ChatToUserDatabase(string userId, Guid chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }


        public string UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
