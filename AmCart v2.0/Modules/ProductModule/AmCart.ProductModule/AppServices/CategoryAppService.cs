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
using System.Linq;
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

        public async Task<OperationResult<CategoryDTO>> CreateAsync(CategoryDTO categoryDTO)
        {
            Category category = mapper.Map<CategoryDTO, Category>(categoryDTO);

            await mongoUnitOfWork.MongoDBRepository.Add(category);
            Message message = new Message(string.Empty, "Inserted Successfully");
            return new OperationResult<CategoryDTO>(categoryDTO, true, message);
        }

     

        public async Task<OperationResult<IEnumerable<CategoryDTO>>> DeleteAsync(string id)
        {
            IEnumerable<Category> categoryList = await mongoUnitOfWork.MongoDBRepository.GetById(id);
            if (categoryList.ToList().Count > 0)
            {
                Message message = new Message(string.Empty, "Deleted Successfully");
                List<CategoryDTO> categoryDTOList = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(categoryList);
                await mongoUnitOfWork.MongoDBRepository.Delete(id);
                return new OperationResult<IEnumerable<CategoryDTO>>(categoryDTOList, true, message);

            }
            else
            {
                return new OperationResult<IEnumerable<CategoryDTO>>(new List<CategoryDTO>(), false, new Message(String.Empty, "Error in deleting"));
            }
        }

        public async Task<OperationResult<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> categoryList = await mongoUnitOfWork.MongoDBRepository.GetAll();
            Message message = new Message(string.Empty, "Return Successfully");
            List<CategoryDTO> categoryDTOList = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(categoryList);
            return new OperationResult<IEnumerable<CategoryDTO>>(categoryDTOList, true, message);
        }

        public async Task<OperationResult<CategoryDTO>> UpdateAsync(CategoryDTO categoryDTO)
        {
            Category category = mapper.Map<CategoryDTO, Category>(categoryDTO);
            await mongoUnitOfWork.MongoDBRepository.Update(category);
            Message message = new Message(string.Empty, "Updated Successfully");
            return new OperationResult<CategoryDTO>(categoryDTO, true, message);
        }

      
    }
}
