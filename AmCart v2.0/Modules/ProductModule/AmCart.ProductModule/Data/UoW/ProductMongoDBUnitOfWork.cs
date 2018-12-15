
using AmCart.Core.Data;
using AmCart.Core.Data.Transaction;
using AmCart.Core.ExceptionManagement;
using AmCart.ProductModule.Data.DBContext;
using AmCart.ProductModule.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.Data.UoW
{
    public class ProductMongoDBUnitOfWork : MongoDBUnitOfWork<Product>, IProductMongoDBUnitOfWork
    {

        public ProductMongoDBUnitOfWork(IOptions<Core.Data.DBSettings> settings) :
            
            base(new MongoConnection(settings.Value.ConnectionString, settings.Value.Database), "Product")
        {

        }
    }
}
