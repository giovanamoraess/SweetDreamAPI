using SweetDream.Business.Base;
using SweetDream.Data;
using SweetDream.Data.Repositories;
using SweetDream.Model.Entidades;

namespace SweetDream.Business
{
    public class CarrinhoBusiness : BaseBusiness<Carrinho>
    {
        private CarrinhoRepository Repository { get { return (CarrinhoRepository)EntityRepository; } }

        public CarrinhoBusiness(Context context)
        {
            EntityRepository = new CarrinhoRepository(context);
        }

        public Carrinho GetCarrinho(string id)
        {
            return Repository.GetCarrinho(id);
        }
    }
}
