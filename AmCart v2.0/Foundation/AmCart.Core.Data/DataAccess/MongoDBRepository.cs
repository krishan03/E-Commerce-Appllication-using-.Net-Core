using AmCart.Core.Domain;
using AmCart.Core.Domain.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.Core.Data.DataAccess
{
    public class MongoDBRepository<TEntity> : IMongoDBRepository<TEntity> where TEntity : DomainBase, IDomain
    {
        private MongoConnection Connection;
        private IMongoCollection<TEntity> collection;

        public MongoDBRepository(MongoConnection connection, string collectionName)
        {
            Connection = connection;
            this.collection = Connection.database.GetCollection<TEntity>(collectionName);
        }
        public void Add(TEntity entity)
        {
            collection.InsertOneAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {

            return await collection.Find(_ => true).ToListAsync();

        }

        async System.Threading.Tasks.Task<IEnumerable<TEntity>> IMongoDBRepository<TEntity>.GetAll()
        {
            return await collection.Find(_ => true).ToListAsync();
        }
    }
}
