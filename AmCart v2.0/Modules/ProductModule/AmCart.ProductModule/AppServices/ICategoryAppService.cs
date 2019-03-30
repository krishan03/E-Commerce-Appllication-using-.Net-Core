using AmCart.Core.AppServices;
using AmCart.Core.ValueObjects;
using AmCart.ProductModule.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.ProductModule.AppServices
{
    public interface ICategoryAppService:IAppService
    {
        Task<OperationResult<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync();
        Task<OperationResult<CategoryDTO>> CreateAsync(CategoryDTO tagGroupDTO);

        Task<OperationResult<CategoryDTO>> UpdateAsync(CategoryDTO tagGroupDTO);

        Task<OperationResult<IEnumerable<CategoryDTO>>> DeleteAsync(string id);
    }
}
