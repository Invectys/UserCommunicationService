using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class InitConnectedUserInput
    {
        public InitConnectedUserInput(string userId)
        {
            UserId = userId;
        }


        public int MaxChats { get => 1000000; }
        public string UserId { get; }
    }
}
