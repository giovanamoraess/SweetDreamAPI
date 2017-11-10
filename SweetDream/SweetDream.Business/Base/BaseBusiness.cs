using MongoDB.Driver;
using SweetDream.Data;
using SweetDream.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Business.Base
{
    public abstract class BaseBusiness <TEntity> where TEntity : class
    {
        protected BaseRepository<TEntity> EntityRepository;

        public virtual TEntity Create(TEntity entity)
        {
            return EntityRepository.Create(entity);
        }
    }
}
