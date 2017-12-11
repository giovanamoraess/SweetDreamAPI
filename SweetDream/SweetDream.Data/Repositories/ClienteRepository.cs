using MongoDB.Bson;
using MongoDB.Driver;
using SweetDream.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        IMongoDatabase database;
        public ClienteRepository(Context context)
            : base(context)
        {
            this.database = context.database;
        }

        public Cliente Logon(Logon logon)
        {
            var filtro = Builders<Cliente>.Filter.Eq(c => c.email, logon.email);
            return collection.Find(filtro).FirstOrDefault();
        }

        public Cliente FindById(string id)
        {
            var filtro = Builders<Cliente>.Filter.Eq(c => c._id, ObjectId.Parse(id));
            return collection.Find(filtro).FirstOrDefault();
        }

        public Cliente FindByEmail(string email)
        {
            var filtro = Builders<Cliente>.Filter.Eq(c => c.email, email);
            return collection.Find(filtro).FirstOrDefault();
        }
    }
}
