
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amcart.Business.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context = null;

        public ProductRepository(IOptions<DBSettings> settings)
        {
            _context = new ProductDbContext(settings);
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _context.Products
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
