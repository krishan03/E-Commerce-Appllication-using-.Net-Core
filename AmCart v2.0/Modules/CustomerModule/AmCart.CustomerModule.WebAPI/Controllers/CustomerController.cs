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
        [HttpGet]
        [ExceptionFilterWebApi]
        public async Task<OperationResult<Customer>> GetProfileAsync()
        {
            return new OperationResult<Customer>(new Customer(), true, new Message("", ""));
        }

        [HttpGet("context")]
        [ExceptionFilterWebApi]
        public async Task<CustomerContext> GetContextAsync()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier);
            Customer customer = null; // Get customer based on userId;
            return new CustomerContext()
            {
                Customer = customer,
                Claims = this.User.Claims.Select(c => new SimpleClaim() { Type = c.Type, Value = c.Value }).ToList()
            };
        }
    }
}
