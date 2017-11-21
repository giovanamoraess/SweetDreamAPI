using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Model.Entidades
{
    public class Produto
    {
        public ObjectId _id { get; set; }
        public string nome { get; set; }
        public decimal valor { get; set; }
    }
}
