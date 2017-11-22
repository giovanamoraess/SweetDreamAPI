using System;
using MongoDB.Driver;
using SweetDream.Model.Entidades;
using MongoDB.Bson;

namespace SweetDream.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        IMongoDatabase database;
        public ProdutoRepository(Context context)
            : base(context)
        {
            this.database = context.database;
        }

        public Produto FindById(string id)
        {
            var filtro = Builders<Produto>.Filter.Eq(c => c._id, ObjectId.Parse(id));
            return collection.Find(filtro).FirstOrDefault();
        }
    }
}
