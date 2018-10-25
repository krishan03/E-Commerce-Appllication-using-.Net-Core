using Amcart.Business.Domain;
using Amcart.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amcart.Business.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
