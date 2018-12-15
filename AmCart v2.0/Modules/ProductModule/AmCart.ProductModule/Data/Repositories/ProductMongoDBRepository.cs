using AmCart.Core.Data;
using AmCart.Core.Data.DataAccess;
using AmCart.ProductModule.Data.DBContext;
using AmCart.ProductModule.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.ProductModule.Data.Repositories
{
    public class ProductMongoDBRepository : MongoDBRepository<Product>, IProductMongoDBRepository
    {
        private MongoConnection connection;

        private string collectionName;
        public ProductMongoDBRepository(MongoConnection connection, string collectionName) : base(connection, collectionName)
        {

        }
    }
}
