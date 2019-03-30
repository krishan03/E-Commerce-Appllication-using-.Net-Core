using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.Core.Domain.Repository
{
    public interface IMongoDBRepository<TEntity> where TEntity : DomainBase, IDomain
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(string id);

        Task<IEnumerable<TEntity>> GetById(string id);


    }
}
