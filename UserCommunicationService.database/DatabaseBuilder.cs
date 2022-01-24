using Cassandra;
using Invectys.media;
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

            // create media user defineded type
            _session.Execute(CreateDatabaseQueries.CreateInvectysMediaUserDefinedType);
            _session.UserDefinedTypes.Define(
                UdtMap.For<InvectysMedia>()
                    .Map(a => a.Type, "type")
                    .Map(a => a.MediaId, "mediaid")
                    .Map(a => a.IsAsset, "isasset")
                    .Map(a => a.CreationTime, "creationtime")
                    .Map(a => a.Tag, "tag")
                    .Map(a => a.CropTop, "croptop")
                    .Map(a => a.CropBottom, "cropbottom")
                    .Map(a => a.CropLeft, "cropleft")
                    .Map(a => a.CropRight, "cropright")
            );

            // User to user messages table creation
            _session.Execute(CreateDatabaseQueries.CreateMessagesTableCQL);

            // Has Chat contains User relation
            // Used for fetching all user chats
            _session.Execute(CreateDatabaseQueries.CreateUserToChatTableCQL);
            _session.Execute(CreateDatabaseQueries.CreateChatToUserTableCQL);
        }

    }
}
