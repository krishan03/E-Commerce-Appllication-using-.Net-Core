using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmCart.Core.ValueObjects;
using AmCart.CustomerModule.AppService;
using AmCart.CustomerModule.AppService.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmCart.CustomerModule.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewCustomerController : ControllerBase
    {
        private INewCustomerAppService customerAppService;
        private IMapper mapper;

        public NewCustomerController(INewCustomerAppService customerAppService, IMapper mapper)
        {
            this.customerAppService = customerAppService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<OperationResult<IEnumerable<CustomerDTO>>> GetAllCustomerAsync()
        {
            return await customerAppService.GetAllCategoriesAsync();
        }

        [HttpPost]
        public async Task<OperationResult<CustomerDTO>> Create(CustomerDTO customerDTO)
        {
            return await customerAppService.CreateAsync(customerDTO);
        }

        [HttpPut]
        public async Task<OperationResult<CustomerDTO>> Update(CustomerDTO categoryDTO)
        {
            return await customerAppService.UpdateAsync(categoryDTO);
        }

        [HttpDelete]
        public async Task<OperationResult<IEnumerable<CustomerDTO>>> Delete(string id)
        {
            return await customerAppService.DeleteAsync(id);
        }
    }
}