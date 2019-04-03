using System;
using System.Collections.Generic;
using System.Text;
using AmCart.Core.Data;
using AmCart.Core.Data.DataAccess;

namespace AmCart.OrderModule.Data.Repositories
{
    public class OrderMongoDBRepository : MongoDBRepository<Order>, IOrderMongoDBRepository
    {
        private MongoConnection connection;

        private string collectionName;
        public OrderMongoDBRepository(MongoConnection connection, string collectionName) : base(connection, collectionName)
        {

        }
    }
}
