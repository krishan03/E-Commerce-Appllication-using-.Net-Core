using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AmCart.Core.ValueObjects;
using AmCart.Core.WebMVC.Filters;
using AmCart.OrderModule.AppServices;
using AmCart.OrderModule.AppServices.DTOs;
using AmCart.OrderModule.Data.Repositories;
using AmCart.OrderModule.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmCart.OrderModule.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IOrderAppService orderAppService;
        private readonly IOrderRepository orderRepository;

        private IMapper mapper;
        public OrderController(IOrderAppService orderAppService, IMapper mapper,IOrderRepository orderRepository)
        {
            this.orderAppService = orderAppService;
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        [Authorize]
        [ExceptionFilterWebApi]
        public async Task<OperationResult<IEnumerable<OrderDTO>>> GetAllOrdersAsync()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier);
            IList<Order> orders = await this.orderRepository.GetOrdersByUserId(userId.Value);
            // use the above aid as userId.Value for sending the user id in order to fetch the orders.
            return await orderAppService.GetAllOrderssAsync(userId.Value);
        }

        [HttpPost]
        [Authorize]
        [ExceptionFilterWebApi]
        public async Task<OperationResult<OrderDTO>> Create(OrderDTO orderDTO)
        {
            return await orderAppService.CreateAsync(orderDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<OperationResult<OrderDTO>> GetById(string id)
        {
            return await orderAppService.GetByIdAsync(id);
        }

    }

}