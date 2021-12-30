using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services.Chats.ChatsModels
{
    public class ChatInList
    {
        public ChatInList(string chatId, string lastMessage)
        {
            ChatId = chatId;
            LastMessage = lastMessage;
        }


        public string ChatId { get; }
        public string LastMessage { get;  }
    }
}
