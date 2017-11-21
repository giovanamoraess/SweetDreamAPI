using SweetDream.Business.Base;
using SweetDream.Data.Repositories;
using SweetDream.Model.Entidades;
using SweetDream.Data;
using System;

namespace SweetDream.Business
{
    public class ClienteBusiness : BaseBusiness<Cliente>
    {
        private ClienteRepository Repository { get { return (ClienteRepository)EntityRepository; } }

        public ClienteBusiness(Context context)
        {
            EntityRepository = new ClienteRepository(context);
        }

        public Cliente Logon(Logon logon)
        {
            var cliente = Repository.Logon(logon);

            if(cliente == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            if(cliente.senha != logon.senha)
            {
                throw new Exception("Senha Invalida");
            }

            return cliente;
        }

        public Cliente FindById(string id)
        {
            return Repository.FindById(id);
        }
    }
}
