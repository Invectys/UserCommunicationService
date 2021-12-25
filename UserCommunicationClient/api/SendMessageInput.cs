using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserCommunicationClient.api
{
    internal class SendMessageInput
    {
        public SendMessageInput(Guid fromId, Guid toId, string content)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
        }


        public Guid FromId { get; }
        public Guid ToId { get; }
        public string Content { get; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public StringContent ToHttpContent()
        {
            return new StringContent(ToJson(), Encoding.UTF8, MediaTypes.JsonMediaType);
        }
    }
}
