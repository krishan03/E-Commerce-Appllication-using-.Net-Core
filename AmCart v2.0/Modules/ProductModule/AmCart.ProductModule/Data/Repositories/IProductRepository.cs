using AmCart.ProductModule.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.ProductModule.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetAllNew();
        Task<IEnumerable<Product>> GetAllPopular();
        Task<IEnumerable<Product>> GetAllBestselling();
    }
}
