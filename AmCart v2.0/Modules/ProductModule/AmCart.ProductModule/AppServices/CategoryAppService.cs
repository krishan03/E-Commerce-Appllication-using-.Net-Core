using AmCart.Core.AppServices;
using AmCart.Core.ExceptionManagement;
using AmCart.Core.ValueObjects;
using AmCart.ProductModule.AppServices.DTOs;
using AmCart.ProductModule.Data.Repositories;
using AmCart.ProductModule.Data.UoW;
using AmCart.ProductModule.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.ProductModule.AppServices
{
    public class CategoryAppService : AppService, ICategoryAppService
    {
        private IMapper mapper;
        private IProductModuleUnitOfWork unitOfWork;
        private IExceptionManager exceptionManager;
        private IProductRepository productRepository;
        private ICategoryUnitOfWork mongoUnitOfWork;


        public CategoryAppService(IProductModuleUnitOfWork unitOfWork, ICategoryUnitOfWork mongoUnitOfWork, IProductRepository productRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            //this.unitOfWork = unitOfWork;
            //this.exceptionManager = exceptionManager;
            this.productRepository = productRepository;
            this.mongoUnitOfWork = mongoUnitOfWork;

        }

        public async Task<OperationResult<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> categoryList = await mongoUnitOfWork.MongoDBRepository.GetAll();
            Message message = new Message(string.Empty, "Return Successfully");
            List<CategoryDTO> categoryDTOList = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(categoryList);
            return new OperationResult<IEnumerable<CategoryDTO>>(categoryDTOList, true, message);
        }




    }
}
