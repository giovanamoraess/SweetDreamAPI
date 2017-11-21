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
    public class CarrinhoRepository : BaseRepository<Carrinho>
    {
        IMongoDatabase database;
        public CarrinhoRepository(Context context)
            : base(context)
        {
            this.database = context.database;
        }

        public Carrinho GetCarrinho(string id)
        {
            var filtro = Builders<Carrinho>.Filter.Eq(c => c.cliente._id, ObjectId.Parse(id));
            return collection.Find(filtro).FirstOrDefault();
        }
    }
}
