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
    }
}
