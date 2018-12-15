
using AmCart.Core.Domain;
using AmCart.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.Core.Data.Transaction
{
    public interface IMongoDBUnitOfWork<TEntity> where TEntity : DomainBase, IDomain
    {
        IMongoDBRepository<TEntity> MongoDBRepository { get; set; }
    }
}
