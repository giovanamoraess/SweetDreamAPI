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
        private readonly VendaBusiness vendaBusiness;

        public CarrinhoController(CarrinhoBusiness carrinhoBusiness, ClienteBusiness clienteBusiness, VendaBusiness vendaBusiness)
        {
            this.carrinhoBusiness = carrinhoBusiness;
            this.clienteBusiness = clienteBusiness;
            this.vendaBusiness = vendaBusiness;
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

        [HttpPost]
        [Route("api/carrinho/adicionarItem")]
        public Carrinho AdicionarItem(AdicionarItem item)
        {
            carrinhoBusiness.AdicionarItem(item);

            return carrinhoBusiness.GetCarrinho(item.idCliente);
        }

        [HttpPost]
        [Route("api/carrinho/removerItem")]
        public Carrinho RemoverItem(RemoverItem item)
        {
            carrinhoBusiness.RemoverItem(item);

            return carrinhoBusiness.GetCarrinho(item.idCliente);
        }

        [HttpPost]
        [Route("api/carrinho/limpar/{idCliente}")]
        public Carrinho RemoverItem(string idCliente)
        {
            carrinhoBusiness.LimparCarrinho(idCliente);

            return carrinhoBusiness.GetCarrinho(idCliente);
        }

        [HttpPost]
        [Route("api/carrinho/finalizar/{idCliente}")]
        public Vendas Finalizar(string idCliente)
        {
            return vendaBusiness.FinalizarVenda(idCliente); ;
        }

        [HttpGet]
        [Route("api/carrinho/vendas/{idCliente}")]
        public List<Vendas> GetVendas(string idCliente)
        {
            return vendaBusiness.FindById(idCliente); ;
        }
    }
}
