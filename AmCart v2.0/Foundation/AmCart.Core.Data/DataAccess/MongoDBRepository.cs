using AmCart.Core.Domain;
using AmCart.Core.Domain.Repository;
using MongoDB.Bson;
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
        public async Task Add(TEntity entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            await collection.FindOneAndUpdateAsync(filter, Builders<TEntity>.Update.Set("IsActive", false));
           
           
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {

            return await collection.Find(_ => true).ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> GetById(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            var entity = await collection.FindAsync(filter);
            return entity.ToList();
        }

        public async Task Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(entity.Id));
            await collection.ReplaceOneAsync(filter, entity);
        }

        async System.Threading.Tasks.Task<IEnumerable<TEntity>> IMongoDBRepository<TEntity>.GetAll()
        {
            return await collection.Find(_ => true).ToListAsync();
        }
    }
}
