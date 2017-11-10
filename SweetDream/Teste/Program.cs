using SweetDream.Data.Repositories;
using System;
using SweetDream.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SweetDream.Model.Entidades;
using SweetDream.Business;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        { 
            var clienteRepository = new ClienteBusiness(new Context());

            var cliente = new Cliente()
            {
                email = "giovana@bla.com",
                nome = "Giovana",
                senha = "123456",
                dataNascimento = new DateTime(1993, 12, 10),
                sexo = Sexo.Feminino,
                telefone = "213213213",
                cartoes = new List<Cartao>()
                {
                    new Cartao()
                    {
                        numero = "21321321321321",
                        bandeira = Bandeira.Master,
                        anoValidade = "2019",
                        mesValidade = "12",
                        nome = "NICHOLAS M GIUDICE",
                        CCV = "213"
                    }
                }
            };

            clienteRepository.Create(cliente);
        }
    }
}
