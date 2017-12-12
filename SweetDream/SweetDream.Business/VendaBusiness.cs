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
        private ClienteBusiness clienteBusiness;

        public VendaBusiness(Context context, CarrinhoBusiness carrinhoBusiness, ClienteBusiness clienteBusiness)
        {
            EntityRepository = new VendaRepository(context);
            this.carrinhoBusiness = carrinhoBusiness;
            this.clienteBusiness = clienteBusiness;
        }

        public Vendas FinalizarVenda(string id, Vendas venda)
        {
            var cliente = clienteBusiness.FindById(id);

            venda.produtos = venda.produtos;
            venda.cliente = cliente;
            venda.data = DateTime.Now;

            var result = Repository.Create(venda);
            return result;
        }

        public List<Vendas> FindById(string FindByClientId)
        {
            return Repository.FindByClientId(FindByClientId);
        }
    }
}
