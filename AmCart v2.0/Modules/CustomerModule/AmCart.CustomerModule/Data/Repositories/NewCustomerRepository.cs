using AmCart.Core.Data;
using AmCart.Core.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.CustomerModule.Data.Repositories
{
    public class NewCustomerRepository : MongoDBRepository<Customer>, INewCustomerRepository
    {
        private MongoConnection connection;

        private string collectionName;
        public NewCustomerRepository(MongoConnection connection, string collectionName) : base(connection, collectionName)
        {

        }
    }
}
