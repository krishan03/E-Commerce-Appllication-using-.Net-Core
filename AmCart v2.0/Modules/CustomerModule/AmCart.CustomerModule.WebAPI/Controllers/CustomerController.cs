using AmCart.Core.ValueObjects;
using AmCart.Core.WebMVC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AmCart.CustomerModule.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository repository)
        {
            this.customerRepository = repository;
        }

        [HttpGet]
        [ExceptionFilterWebApi]
        public async Task<OperationResult<Customer>> GetProfileAsync()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier);
            Customer customer = await this.customerRepository.GetByUserId(userId.Value);
            return new OperationResult<Customer>(customer, true, new Message("", ""));
        }

        [HttpGet("context")]
        [ExceptionFilterWebApi]
        public async Task<OperationResult<CustomerContext>> GetContextAsync()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier);
            Customer customer = await this.customerRepository.GetByUserId(userId.Value);
            CustomerContext customerContext = new CustomerContext()
            {
                Customer = customer,
                Claims = this.User.Claims.Select(c => new SimpleClaim() { Type = c.Type, Value = c.Value }).ToList()
            };

            return new OperationResult<CustomerContext>(customerContext, true, new Message("", ""));
        }
    }
}
