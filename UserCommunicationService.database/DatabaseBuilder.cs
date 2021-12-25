using Cassandra;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunicationService.database.CQL;

namespace UserCommunicationService.database
{
    public class DatabaseBuilder
    {

        private string _address = "194.67.104.187";
        private Database _database;
        private Cluster _cluster;
        private ISession _session;
        private ILoggerProvider _provider;

        public Database BuildDatabase()
        {
            if(_database != null)
            {
                throw new Exception("Use DI to retreive database. You cannot build database more then once");
            }
            Init();

            _database = new Database(_session, _cluster);
            return _database;
        }

        private void Init()
        {
            BuildCluster();
            ConnectToCluster();
            CreateIfNotExist();
        }

        private void BuildCluster()
        {
            _cluster = Cluster.Builder()
                    .AddContactPoint(_address)
                    .Build();
        }

        private void ConnectToCluster()
        {
            _session = _cluster.Connect();
        }

        private void CreateIfNotExist()
        {
            // Keyspace creation for user communications
            _session.Execute(CreateDatabaseQueries.CreateKeyspaceCQL);

            _session.ChangeKeyspace(Constants.KeyspaceName);

            // User to user messages table creation
            _session.Execute(CreateDatabaseQueries.CreateMessagesTableCQL);
        }

    }
}
