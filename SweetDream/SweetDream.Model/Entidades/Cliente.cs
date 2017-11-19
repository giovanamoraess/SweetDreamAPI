using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Model.Entidades
{
    public class Cliente
    {
        public ObjectId _id { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public Sexo sexo { get; set; }
        public string telefone { get; set; }
        public List<Cartao> cartoes { get; set; }
    }
}
