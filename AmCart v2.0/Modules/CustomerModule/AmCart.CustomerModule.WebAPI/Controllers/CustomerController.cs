using AmCart.Core.ValueObjects;
using AmCart.Core.WebMVC.Filters;
using AmCart.CustomerModule.AppService.DTOs;
using AutoMapper;
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

        private readonly IMapper mapper;

        public CustomerController(ICustomerRepository repository, IMapper mapper)
        {
            this.customerRepository = repository;
            this.mapper = mapper;
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

        [HttpPost]
        [Route("cart")]
        public async Task<OperationResult> AddItemInCart(CartProductDTO cartProduct)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier);
            CartProduct product = mapper.Map<CartProductDTO, CartProduct>(cartProduct);
            await this.customerRepository.AddItemInCart(userId.Value, product);
            return new OperationResult(true, new Message("", ""));
        }

        [HttpPost]
        [Route("wishlist")]
        public async Task<OperationResult> AddItemInWishlist(ProductLiteDTO wishlistProduct)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier);
            ProductLite product = mapper.Map<ProductLiteDTO, ProductLite>(wishlistProduct);
            await this.customerRepository.AddItemInWishlist(userId.Value, product);
            return new OperationResult(true, new Message("", ""));
        }

        [HttpGet]
        [Route("emptyCart")]
        [AllowAnonymous]
        public async Task<OperationResult> EmptyCart(string userId)
        {
            await this.customerRepository.EmptyCart(userId);
            return new OperationResult(true, new Message("", ""));
        }
    }
}
