using AmCart.Core.ValueObjects;
using AmCart.Core.WebMVC.Filters;
using AmCart.ProductModule.AppServices;
using AmCart.ProductModule.AppServices.DTOs;
using AmCart.ProductModule.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.ProductModule.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductAppService productAppService;
        private IMapper mapper;

        public ProductController(IProductAppService productAppService, IMapper mapper)
        {
            this.productAppService = productAppService;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [ExceptionFilterWebApi]
        public async Task<OperationResult<IEnumerable<ProductDTO>>> GetAllProductsAsync()
        {
            //Message msg = new Message("ExternalService", "error");
            //return new OperationResult<IEnumerable<ProductDTO>>(null, false, msg);
            // throw new DivideByZeroException();
            
                return await productAppService.GetAllProductsAsync();

        }

        [HttpGet]
        [AllowAnonymous]
        [ExceptionFilterWebApi]
        [Route("new")]
        public async Task<OperationResult<IEnumerable<ProductDTO>>> GetAllNewProductsAsync()
        {
            //Message msg = new Message("ExternalService", "error");
            //return new OperationResult<IEnumerable<ProductDTO>>(null, false, msg);
            // throw new DivideByZeroException();

            return await productAppService.GetAllNewProductsAsync();

        }

        [HttpGet]
        [AllowAnonymous]
        [ExceptionFilterWebApi]
        [Route("popular")]
        public async Task<OperationResult<IEnumerable<ProductDTO>>> GetAllPopularProductsAsync()
        {
            //Message msg = new Message("ExternalService", "error");
            //return new OperationResult<IEnumerable<ProductDTO>>(null, false, msg);
            // throw new DivideByZeroException();

            return await productAppService.GetAllPopularProductsAsync();

        }

        [HttpGet]
        [AllowAnonymous]
        [ExceptionFilterWebApi]
        [Route("bestseller")]
        public async Task<OperationResult<IEnumerable<ProductDTO>>> GetAllBestsellerProductsAsync()
        {
            //Message msg = new Message("ExternalService", "error");
            //return new OperationResult<IEnumerable<ProductDTO>>(null, false, msg);
            // throw new DivideByZeroException();

            return await productAppService.GetAllBestsellerProductsAsync();

        }
    }
}