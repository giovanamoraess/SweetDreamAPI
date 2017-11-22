using System;
using SweetDream.Business.Base;
using SweetDream.Data;
using SweetDream.Data.Repositories;
using SweetDream.Model.Entidades;
using MongoDB.Bson;
using System.Linq;
using System.Collections.Generic;

namespace SweetDream.Business
{
    public class CarrinhoBusiness : BaseBusiness<Carrinho>
    {
        private CarrinhoRepository Repository { get { return (CarrinhoRepository)EntityRepository; } }
        private ProdutoBusiness produtoBusiness;

        public CarrinhoBusiness(Context context, ProdutoBusiness produtoBusiness)
        {
            EntityRepository = new CarrinhoRepository(context);
            this.produtoBusiness = produtoBusiness;
        }

        public Carrinho GetCarrinho(string id)
        {
            return Repository.GetCarrinho(id);
        }

        public void AdicionarItem(AdicionarItem item)
        {
            var carrinho = Repository.GetCarrinho(item.idCliente);

            var produto = produtoBusiness.GetById(item.idProduto);

            carrinho.produtos.Add(new Produtos() { produto = produto, quantidade = item.quantidade });

            Repository.UpdateCarrinho(carrinho);
        }

        public void RemoverItem(RemoverItem item)
        {
            var carrinho = Repository.GetCarrinho(item.idCliente);
            var itemDeletar = carrinho.produtos.FirstOrDefault(p => p.produto._id == ObjectId.Parse(item.idProduto));

            if(itemDeletar != null)
            {
                if (item.quantidade == 0)
                {
                    carrinho.produtos.Remove(itemDeletar);
                }
                else
                {
                    if (itemDeletar.quantidade == item.quantidade)
                    {
                        carrinho.produtos.Remove(itemDeletar);
                    }
                    else
                    {
                        itemDeletar.quantidade -= item.quantidade;
                    }
                }
            }

            Repository.UpdateCarrinho(carrinho);
        }

        public void LimparCarrinho(string idCliente)
        {
            var carrinho = Repository.GetCarrinho(idCliente);
            carrinho.produtos = new List<Produtos>();
            Repository.UpdateCarrinho(carrinho);
        }
    }
}
