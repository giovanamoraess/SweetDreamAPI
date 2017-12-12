using System;
using MongoDB.Driver;
using SweetDream.Model.Entidades;
using MongoDB.Bson;
using System.Collections.Generic;

namespace SweetDream.Data.Repositories
{
    public class VendaRepository : BaseRepository<Vendas>
    {
        IMongoDatabase database;
        public VendaRepository(Context context)
            : base(context)
        {
            this.database = context.database;
        }

        public List<Vendas> FindByClientId(string id)
        {
            var filtro = Builders<Vendas>.Filter.Eq(c => c.cliente._id, ObjectId.Parse(id));
            return collection.Find(filtro).ToList();
        }
    }
}
