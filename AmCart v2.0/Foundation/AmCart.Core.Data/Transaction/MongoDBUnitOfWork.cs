using AmCart.Core.Data.DataAccess;
using AmCart.Core.Domain;
using AmCart.Core.Domain.Repository;
using AmCart.Core.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.Core.Data.Transaction
{
    public class MongoDBUnitOfWork<TEntity> : IMongoDBUnitOfWork<TEntity> where TEntity : DomainBase, IDomain
    {

        private MongoConnection Connection;
        private string collectionName;
        public MongoDBUnitOfWork(MongoConnection connection, string collectionName)
        {
            this.Connection = connection;
            this.collectionName = collectionName;
        }

        private IMongoDBRepository<TEntity> IMongoDbRepository;

        public IMongoDBRepository<TEntity> MongoDBRepository
        {
            get { return IMongoDbRepository ?? new MongoDBRepository<TEntity>(Connection, collectionName); }
            set { IMongoDbRepository = value; }
        }




    }
}
