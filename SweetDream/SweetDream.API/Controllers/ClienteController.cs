using SweetDream.Business;
using SweetDream.Infrastructure.Excepetion;
using SweetDream.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;
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
            catch (BaseBusinessException e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = HttpStatusCode.BadRequest.ToString(), Content = new StringContent(e.Message) });
            }
            catch (Exception e)
            {
                throw e;
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
            catch(BaseBusinessException e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden) { ReasonPhrase = HttpStatusCode.Forbidden.ToString(), Content = new StringContent(e.Message) });
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
