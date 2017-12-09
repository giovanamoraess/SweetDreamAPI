using SweetDream.Business.Base;
using SweetDream.Data.Repositories;
using SweetDream.Model.Entidades;
using SweetDream.Data;
using System;
using System.Net.Http;
using System.Net;
using SweetDream.Infrastructure.Excepetion;

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
                throw new BaseBusinessException("Cliente não encontrado");
            }

            if(cliente.senha != logon.senha)
            {
                throw new BaseBusinessException("Senha Invalida");
            }

            return cliente;
        }

        public Cliente FindById(string id)
        {
            return Repository.FindById(id);
        }

        public override Cliente Create(Cliente entity)
        {
            if(Repository.FindByEmail(entity.email) != null)
            {
                throw new BaseBusinessException("Usuário já cadastrado");
            }

            return base.Create(entity);
        }
    }
}
