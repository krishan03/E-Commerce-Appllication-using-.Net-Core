using Amcart.Business.Data.DBContext;
using Amcart.Business.Domain;
using Amcart.Core.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amcart.Business.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
