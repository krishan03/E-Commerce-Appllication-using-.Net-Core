using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amcart.Business.AppService;
using Amcart.Business.AppService.DTOs;
using Amcart.Core.ValueObjects;
using Amcart.Core.WebMVC.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amcart.Web.API.Controllers
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

        public OperationResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            //Message msg = new Message("ExternalService", "error");
            //return new OperationResult<IEnumerable<ProductDTO>>(null, false, msg);
            // throw new DivideByZeroException();
            return productAppService.GetAllProducts();

        }
    }
}