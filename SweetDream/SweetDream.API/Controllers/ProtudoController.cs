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
    public class ProdutoController : ApiController
    {
        private ProdutoBusiness produtoBusiness;

        public ProdutoController(ProdutoBusiness produtoBusiness)
        {
            this.produtoBusiness = produtoBusiness;
        }

        [HttpPost]
        public Produto Create(Produto produto)
        {
            try
            {
                return produtoBusiness.Create(produto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public List<Produto> RetieveAll()
        {
            try
            {
                return produtoBusiness.RetrieveAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
