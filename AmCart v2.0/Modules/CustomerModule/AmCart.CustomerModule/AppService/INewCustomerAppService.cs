using AmCart.Core.AppServices;
using AmCart.Core.ValueObjects;
using AmCart.CustomerModule.AppService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.CustomerModule.AppService
{
    public interface INewCustomerAppService : IAppService
    {
        Task<OperationResult<IEnumerable<CustomerDTO>>> GetAllCategoriesAsync();
        Task<OperationResult<CustomerDTO>> CreateAsync(CustomerDTO tagGroupDTO);

        Task<OperationResult<CustomerDTO>> UpdateAsync(CustomerDTO tagGroupDTO);

        Task<OperationResult<IEnumerable<CustomerDTO>>> DeleteAsync(string id);
    }
}
