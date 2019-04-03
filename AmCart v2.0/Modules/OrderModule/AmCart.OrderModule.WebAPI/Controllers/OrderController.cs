using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AmCart.Core.ValueObjects;
using AmCart.Core.WebMVC.Filters;
using AmCart.OrderModule.AppServices;
using AmCart.OrderModule.AppServices.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmCart.OrderModule.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IOrderAppService orderAppService;

        private IMapper mapper;
        public OrderController(IOrderAppService orderAppService, IMapper mapper)
        {
            this.orderAppService = orderAppService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ExceptionFilterWebApi]
        public async Task<OperationResult<IEnumerable<OrderDTO>>> GetAllOrdersAsync()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier);
            // use the above aid as userId.Value for sending the user id in order to fetch the orders.
            return await orderAppService.GetAllOrderssAsync(userId.Value);
        }

    }

}