using AmCart.Core.Data;
using AmCart.Core.Data.Transaction;
using AmCart.Core.Domain.Repository;
using AmCart.ProductModule.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.Data.UoW
{
    public class CategoryUnitOfWork : MongoDBUnitOfWork<Category>, ICategoryUnitOfWork
    {
        public CategoryUnitOfWork(IOptions<Core.Data.DBSettings> settings):
            base(new MongoConnection(settings.Value.ConnectionString, settings.Value.Database), "Category")
        {

        }
    }
}
