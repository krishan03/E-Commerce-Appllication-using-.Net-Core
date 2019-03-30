using AmCart.Core.Data;
using AmCart.Core.Data.DataAccess;
using AmCart.ProductModule.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.Data.Repositories
{
    public class CategoryMongoDBRepository : MongoDBRepository<Category>, ICategoryMongoDBRepository
    {
        private MongoConnection connection;

        private string collectionName;
        public CategoryMongoDBRepository(MongoConnection connection, string collectionName) : base(connection, collectionName)
        {

        }
    }
   
}
