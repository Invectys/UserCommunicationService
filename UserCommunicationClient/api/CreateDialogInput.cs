using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    public class CreateDialogInput
    {
        public CreateDialogInput(Guid firstUserId, Guid secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }


        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
    }
}
