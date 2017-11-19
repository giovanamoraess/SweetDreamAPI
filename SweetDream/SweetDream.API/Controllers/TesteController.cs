using Microsoft.Practices.Unity;
using SweetDream.Business;
using SweetDream.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SweetDream.API.Controllers
{
    public class TesteController : ApiController
    {
        private readonly ClienteBusiness clienteBusiness;

        public TesteController(ClienteBusiness clienteBusiness)
        {
            this.clienteBusiness = clienteBusiness;
        }

        [Route("api/nicholas/")]
        [HttpGet]
        public Teste Get()
        {

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

            clienteBusiness.Create(cliente);
            return new Teste() { nome = "Nicholas" };
        }
    }

    public class Teste
    {
        public string nome { get; set; }
    }
}
