using AmCart.Core.AppServices;
using AmCart.Core.ValueObjects;
using AmCart.ProductModule.AppServices.DTOs;
using AmCart.ProductModule.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.ProductModule.AppServices
{
    public interface IProductAppService : IAppService
    {
        //OperationResult<ProductDTO> Create(ProductDTO item);
         Task<OperationResult<IEnumerable<ProductDTO>>> GetAllProductsAsync();
         Task<OperationResult<IEnumerable<ProductDTO>>> GetAllNewProductsAsync();
         Task<OperationResult<IEnumerable<ProductDTO>>> GetAllPopularProductsAsync();
         Task<OperationResult<IEnumerable<ProductDTO>>> GetAllBestsellerProductsAsync();

        Task<OperationResult<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync();

        Task<OperationResult<ProductDTO>> GetByIdAsync(string id);


    }
}
