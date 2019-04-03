using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AmCart.Core.ValueObjects;
using AmCart.CustomerModule.AppService.DTOs;
using AmCart.Core.AppServices;
using AutoMapper;
using AmCart.Core.ExceptionManagement;
using AmCart.CustomerModule.Data.UoW;
using System.Linq;

namespace AmCart.CustomerModule.AppService
{
    public class NewCustomerAppService : AmCart.Core.AppServices.AppService, INewCustomerAppService
    {
        private IMapper mapper;
        private ICustomerModuleUnitOfWork unitOfWork;
        private IExceptionManager exceptionManager;
        private ICustomerRepository productRepository;
        private INewCustomerUnitOfWork mongoUnitOfWork;


        public NewCustomerAppService(ICustomerModuleUnitOfWork unitOfWork, INewCustomerUnitOfWork mongoUnitOfWork, ICustomerRepository productRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            //this.unitOfWork = unitOfWork;
            //this.exceptionManager = exceptionManager;
            this.productRepository = productRepository;
            this.mongoUnitOfWork = mongoUnitOfWork;

        }
        public async Task<OperationResult<CustomerDTO>> CreateAsync(CustomerDTO customerDTO)
        {
            Customer customer = mapper.Map<CustomerDTO, Customer>(customerDTO);

            await mongoUnitOfWork.MongoDBRepository.Add(customer);
            Message message = new Message(string.Empty, "Inserted Successfully");
            return new OperationResult<CustomerDTO>(customerDTO, true, message);
        }

        public async Task<OperationResult<IEnumerable<CustomerDTO>>> DeleteAsync(string id)
        {
            IEnumerable<Customer> customerList = await mongoUnitOfWork.MongoDBRepository.GetById(id);
            if (customerList.ToList().Count > 0)
            {
                Message message = new Message(string.Empty, "Deleted Successfully");
                List<CustomerDTO> customerDTOList = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(customerList);
                await mongoUnitOfWork.MongoDBRepository.Delete(id);
                return new OperationResult<IEnumerable<CustomerDTO>>(customerDTOList, true, message);

            }
            else
            {
                return new OperationResult<IEnumerable<CustomerDTO>>(new List<CustomerDTO>(), false, new Message(String.Empty, "Error in deleting"));
            }
        }

        public async Task<OperationResult<IEnumerable<CustomerDTO>>> GetAllCategoriesAsync()
        {
            IEnumerable<Customer> customerList = await mongoUnitOfWork.MongoDBRepository.GetAll();
            Message message = new Message(string.Empty, "Return Successfully");
            List<CustomerDTO> customerDTOList = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(customerList);
            return new OperationResult<IEnumerable<CustomerDTO>>(customerDTOList, true, message);
        }

        public async Task<OperationResult<CustomerDTO>> UpdateAsync(CustomerDTO customerDTO)
        {
            Customer customer = mapper.Map<CustomerDTO, Customer>(customerDTO);
            await mongoUnitOfWork.MongoDBRepository.Update(customer);
            Message message = new Message(string.Empty, "Updated Successfully");
            return new OperationResult<CustomerDTO>(customerDTO, true, message);
        }
    }
}
