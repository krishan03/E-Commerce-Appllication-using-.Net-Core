using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amcart.Business.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
