using SweetDream.Business.Base;
using SweetDream.Data.Repositories;
using SweetDream.Model.Entidades;
using SweetDream.Data;

namespace SweetDream.Business
{
    public class ClienteBusiness : BaseBusiness<Cliente>
    {
        private ClienteRepository Repository { get { return (ClienteRepository)EntityRepository; } }

        public ClienteBusiness(Context context)
        {
            EntityRepository = new ClienteRepository(context);
        }
    }
}
