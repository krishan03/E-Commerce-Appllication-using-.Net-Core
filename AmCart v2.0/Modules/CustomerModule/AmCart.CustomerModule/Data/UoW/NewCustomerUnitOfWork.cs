using AmCart.Core.Data;
using AmCart.Core.Data.Transaction;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.CustomerModule.Data.UoW
{
    public class NewCustomerUnitOfWork : MongoDBUnitOfWork<Customer>, INewCustomerUnitOfWork
    {
        public NewCustomerUnitOfWork(IOptions<Core.Data.DBSettings> settings) :
            base(new MongoConnection(settings.Value.ConnectionString, settings.Value.Database), "Customer")
        {

        }
    }
}
