using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services
{
    public class RedisService
    {
        public RedisService(ConnectionMultiplexer connectionMultiplexer)
        {
            _redis = connectionMultiplexer;
        }


        public ConnectionMultiplexer Redis { get => _redis;  }
        public IDatabase Database { get => Redis.GetDatabase(); }


        private ConnectionMultiplexer _redis;
    }
}
