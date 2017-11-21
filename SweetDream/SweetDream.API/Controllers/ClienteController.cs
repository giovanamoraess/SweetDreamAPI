using SweetDream.Business;
using SweetDream.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SweetDream.API.Controllers
{
    public class ClienteController : ApiController
    {

        private readonly ClienteBusiness clienteBusiness;
        private readonly CarrinhoBusiness carrinhoBusiness;

        public ClienteController(ClienteBusiness clienteBusiness, CarrinhoBusiness carrinhoBusiness)
        {
            this.clienteBusiness = clienteBusiness;
            this.carrinhoBusiness = carrinhoBusiness;
        }

        [HttpPost]
        public Cliente Create(Cliente cliente)
        {
            try
            {
                var result = clienteBusiness.Create(cliente);

                if (result != null)
                {
                    var carrinho = new Carrinho() { cliente = result };
                    carrinhoBusiness.Create(carrinho);
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        [Route("api/cliente/logon")]
        [HttpPost]
        public Cliente Logon(Logon logon)
        {
            try
            {
                return clienteBusiness.Logon(logon);
            }
            catch(Exception e)
            {
                throw e;
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = e.Message, Content = new StringContent(e.Message) });
            }
        }
    }
}
