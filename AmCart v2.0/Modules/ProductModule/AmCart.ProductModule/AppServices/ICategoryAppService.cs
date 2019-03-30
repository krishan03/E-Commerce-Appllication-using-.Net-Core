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
    }
}
