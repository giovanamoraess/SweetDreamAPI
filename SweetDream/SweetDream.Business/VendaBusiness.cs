using System;
using SweetDream.Business.Base;
using SweetDream.Data;
using SweetDream.Data.Repositories;
using SweetDream.Model.Entidades;
using MongoDB.Bson;
using System.Linq;
using System.Collections.Generic;
using SweetDream.Infrastructure.Excepetion;

namespace SweetDream.Business
{
    public class VendaBusiness : BaseBusiness<Vendas>
    {
        private VendaRepository Repository { get { return (VendaRepository)EntityRepository; } }
        private CarrinhoBusiness carrinhoBusiness;

        public VendaBusiness(Context context, CarrinhoBusiness carrinhoBusiness)
        {
            EntityRepository = new VendaRepository(context);
            this.carrinhoBusiness = carrinhoBusiness;
        }

        public Vendas FinalizarVenda(string id, Vendas venda)
        {
            var carrinho = carrinhoBusiness.GetCarrinho(id);

            if (carrinho == null || !carrinho.produtos.Any())
            {
                throw new BaseBusinessException("Carrinho Vazio");
            }

            venda.produtos = carrinho.produtos;
            venda.cliente = carrinho.cliente;
            venda.data = DateTime.Now;

            var result = Repository.Create(venda);
            carrinhoBusiness.LimparCarrinho(carrinho.cliente._id.ToString());
            return result;
        }

        public List<Vendas> FindById(string FindByClientId)
        {
            return Repository.FindByClientId(FindByClientId);
        }
    }
}
