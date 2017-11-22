using MongoDB.Bson;
using SweetDream.Business.Base;
using SweetDream.Data;
using SweetDream.Data.Repositories;
using SweetDream.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Business
{
    public class ProdutoBusiness : BaseBusiness<Produto>
    {
        private ProdutoRepository Repository { get { return (ProdutoRepository)EntityRepository; } }

        public ProdutoBusiness(Context context)
        {
            EntityRepository = new ProdutoRepository(context);
        }

        public Produto GetById(string id)
        {
            return Repository.FindById(id);
        }
    }
}
