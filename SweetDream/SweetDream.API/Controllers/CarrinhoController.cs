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
    public class CarrinhoController : ApiController
    {
        private readonly CarrinhoBusiness carrinhoBusiness;
        private readonly ClienteBusiness clienteBusiness;

        public CarrinhoController(CarrinhoBusiness carrinhoBusiness, ClienteBusiness clienteBusiness)
        {
            this.carrinhoBusiness = carrinhoBusiness;
            this.clienteBusiness = clienteBusiness;
        }

        [HttpGet]
        public Carrinho GetCarrinho(string id)
        {
            try
            {
                return carrinhoBusiness.GetCarrinho(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
