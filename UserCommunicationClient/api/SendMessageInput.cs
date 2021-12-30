using Newtonsoft.Json;
using System.Text;

namespace UserCommunicationClient.api
{
    internal class SendMessageInput
    {
        public SendMessageInput(Guid fromId, Guid toId, Guid chatId,  string content)
        {
            ToId = toId;
            FromId = fromId;
            Content = content;
            ChatId = chatId;
        }


        public Guid FromId { get; }
        public Guid ToId { get; }
        public Guid ChatId { get; }
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
