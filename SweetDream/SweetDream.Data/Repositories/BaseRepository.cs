using MongoDB.Driver;
using SweetDream.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Data.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected IMongoDatabase database;
        protected IMongoCollection<TEntity> collection; 
        public BaseRepository(Context context)
        {
            this.database = context.database;
            collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual TEntity Create(TEntity entidade)
        {
            collection.InsertOne(entidade);
            return entidade;
        }

        public virtual List<TEntity> RetrieveAll()
        {
            return collection.Find(_ => true).ToList();
        }
    }
}
