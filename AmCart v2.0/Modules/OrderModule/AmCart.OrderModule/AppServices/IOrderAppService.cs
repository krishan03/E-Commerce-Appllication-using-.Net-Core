using AmCart.Core.AppServices;
using AmCart.Core.ValueObjects;
using AmCart.OrderModule.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.OrderModule.AppServices
{
    public interface IOrderAppService : IAppService
    {
        //OperationResult<ProductDTO> Create(ProductDTO item);
        Task<OperationResult<IEnumerable<OrderDTO>>> GetAllOrderssAsync(string userid);

        Task<OperationResult<OrderDTO>> CreateAsync(OrderDTO orderDTO);

        Task<OperationResult<OrderDTO>> GetByIdAsync(string id);
    }
}
