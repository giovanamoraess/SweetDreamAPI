using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Model.Entidades
{
    public class Vendas
    {
        Cliente cliente { get; set; }
        public List<Produtos> produtos { get; set; }
        public DateTime data { get; set; }
        public Status status { get; set; }
        public Endereco enderecos { get; set; }
        public Cartao cartao { get; set; }
    }
}
