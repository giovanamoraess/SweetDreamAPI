using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Model.Entidades
{
    public class Carrinho
    {
        public Carrinho()
        {
            this.produtos = new List<Produtos>();
            this.dataModificacao = DateTime.Now;
        }
        public ObjectId _id { get; set; }
        public Cliente cliente { get; set; }
        public DateTime dataModificacao { get; set; }
        public List<Produtos> produtos { get; set; }
    }
}
