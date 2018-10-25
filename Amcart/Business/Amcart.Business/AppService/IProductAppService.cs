using Amcart.Business.AppService.DTOs;
using Amcart.Core.AppServices;
using Amcart.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amcart.Business.AppService
{
    public interface IProductAppService : IAppService
    {
        OperationResult<ProductDTO> Create(ProductDTO item);
        OperationResult<IEnumerable<ProductDTO>> GetAllProducts();
    }
}
