using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Model.Entidades
{
    public class Carrinho
    {
        public Cliente cliente { get; set; }
        public DateTime dataModificacao { get; set; }
        public List<Produtos> produtos { get; set; }
    }
}
