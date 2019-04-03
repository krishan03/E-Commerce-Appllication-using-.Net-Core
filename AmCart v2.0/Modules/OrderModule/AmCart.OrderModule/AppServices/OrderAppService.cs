using AmCart.Core.AppServices;
using AmCart.Core.ExceptionManagement;
using AmCart.Core.ValueObjects;
using AmCart.OrderModule.AppServices.DTOs;
using AmCart.OrderModule.Data.Repositories;
using AmCart.OrderModule.Data.UoW;
using AmCart.OrderModule.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.OrderModule.AppServices
{
    public class OrderAppService : AppService, IOrderAppService
    {
        private IMapper mapper;
        private IOrderModuleUnitOfWork unitOfWork;
        private IExceptionManager exceptionManager;
        private IOrderRepository orderRepository;
        private IOrderMongoDBUnitOfWork mongoUnitOfWork;

        public OrderAppService(IOrderModuleUnitOfWork unitOfWork, IOrderMongoDBUnitOfWork mongoUnitOfWork, IOrderRepository orderRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
            this.mongoUnitOfWork = mongoUnitOfWork;
        }

        public async Task<OperationResult<OrderDTO>> CreateAsync(OrderDTO orderDTO)
        {
            Order order = mapper.Map<OrderDTO, Order>(orderDTO);

            await mongoUnitOfWork.MongoDBRepository.Add(order);
            Message message = new Message(string.Empty, "Inserted Successfully");
            return new OperationResult<OrderDTO>(orderDTO, true, message);
        }

        public async System.Threading.Tasks.Task<OperationResult<IEnumerable<OrderDTO>>> GetAllOrderssAsync(string userid)
        {
            IEnumerable<Order> orderList = await mongoUnitOfWork.MongoDBRepository.GetById(userid);
            Message message = new Message(string.Empty, "Return Successfully");
            List<OrderDTO> orderDTOList = mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orderList);
            return new OperationResult<IEnumerable<OrderDTO>>(orderDTOList, true, message);
        }

        public async Task<OperationResult<OrderDTO>> GetByIdAsync(string id)
        {
            IEnumerable<Order> orderList = await mongoUnitOfWork.MongoDBRepository.GetById(id);
            List<OrderDTO> orderDTOList = mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orderList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<OrderDTO>(orderDTOList.First(), true, message);
        }
    }
}
