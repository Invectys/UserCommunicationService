using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class CreateDialogInput
    {
        public CreateDialogInput(string firstUserId, string secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }


        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
    }
}
