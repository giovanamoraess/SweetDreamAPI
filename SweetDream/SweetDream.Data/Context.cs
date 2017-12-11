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
            var client = new MongoClient("mongodb://nicholas:nicholas@ds133166.mlab.com:33166/sweetdream");
            database = client.GetDatabase("sweetdream");
        }
    }
}
