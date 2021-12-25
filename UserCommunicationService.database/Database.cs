using Cassandra;
using Cassandra.Mapping;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunicationService.database.CQL;

namespace UserCommunicationService.database
{
    public class Database
    {
        public Database(ISession session, Cluster cluster)
        {
            _session = session;
            _cluster = cluster;
            _provider = new NLogLoggerProvider();
            Cassandra.Diagnostics.AddLoggerProvider(_provider);

            Mapper = new Mapper(_session);
        }

        private ISession _session;
        private Cluster _cluster;
        private ILoggerProvider _provider;


        public IMapper Mapper { get; }
        public ISession Session { get => _session; }

        public void Shutdown()
        {
            _cluster.Shutdown();
        }
    }
}
