using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmCart.Core.ValueObjects;
using AmCart.ProductModule.AppServices;
using AmCart.ProductModule.AppServices.DTOs;
using AmCart.ProductModule.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmCart.ProductModule.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryAppService categoryAppService;
        private IMapper mapper;

        public CategoryController(ICategoryAppService categoryAppService,IMapper mapper)
        {
            this.categoryAppService = categoryAppService;
            this.mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync()
        {
            return await categoryAppService.GetAllCategoriesAsync();
        }
    }
}