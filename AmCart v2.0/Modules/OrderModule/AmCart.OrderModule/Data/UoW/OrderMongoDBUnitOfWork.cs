using AmCart.Core.Data.Transaction;
using Microsoft.Extensions.Options;
using System;
using AmCart.Core.Data;
using System.Collections.Generic;
using System.Text;
using AmCart.OrderModule.Domain;

namespace AmCart.OrderModule.Data.UoW
{
    public class OrderMongoDBUnitOfWork : MongoDBUnitOfWork<Order>, IOrderMongoDBUnitOfWork
    {
        public OrderMongoDBUnitOfWork(IOptions<Core.Data.DBSettings> settings) :
            base(new MongoConnection(settings.Value.ConnectionString, settings.Value.Database), "Order")
        {
        }
    }
}