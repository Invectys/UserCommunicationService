using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services
{
    public class RedisBuilder
    {

        private string _host = "194.67.104.187:6379";
        private ConnectionMultiplexer _redis;


        public RedisService BuildRedis()
        {
            Connect();
            return new RedisService(_redis);
        }

        private void Connect()
        {
            _redis = ConnectionMultiplexer.Connect(_host);
        }
        
    }
}
