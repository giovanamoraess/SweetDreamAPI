using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Data
{
    public class Context
    {
        public IMongoDatabase database;

        public Context()
        {
            var settings = new MongoClientSettings()
            {
                ServerSelectionTimeout = new TimeSpan(0, 0, 5),
                Server = new MongoServerAddress("localhost", 27017)
            };

            var client = new MongoClient(settings);

            database = client.GetDatabase("teste");
        }
    }
}
