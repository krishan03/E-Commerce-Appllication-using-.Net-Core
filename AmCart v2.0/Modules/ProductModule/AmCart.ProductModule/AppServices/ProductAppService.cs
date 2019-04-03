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
    public class ProductAppService : AppService, IProductAppService
    {
        private IMapper mapper;
        private IProductModuleUnitOfWork unitOfWork;
        private IExceptionManager exceptionManager;
        private IProductRepository productRepository;
        private IProductMongoDBUnitOfWork mongoUnitOfWork;


        public ProductAppService(IProductModuleUnitOfWork unitOfWork, IProductMongoDBUnitOfWork mongoUnitOfWork, IProductRepository productRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            //this.unitOfWork = unitOfWork;
            //this.exceptionManager = exceptionManager;
            this.productRepository = productRepository;
            this.mongoUnitOfWork = mongoUnitOfWork;

        }

       
        

        public async System.Threading.Tasks.Task<OperationResult<IEnumerable<ProductDTO>>> GetAllProductsAsync()
        {
           
            IEnumerable<Product> productList = await mongoUnitOfWork.MongoDBRepository.GetAll();
            Message message = new Message(string.Empty, "Return Successfully");
            List<ProductDTO> productDTOList = mapper.Map <IEnumerable<Product>, List<ProductDTO>>(productList);
            return new OperationResult<IEnumerable<ProductDTO>>(productDTOList, true, message);
        }

        public Task<OperationResult<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<OperationResult<ProductDTO>> GetByIdAsync(string id)
        {
            IEnumerable<Product> productList = await mongoUnitOfWork.MongoDBRepository.GetById(id);
            List<ProductDTO> productDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<ProductDTO>(productDTOList.First(), true, message);

        }


        public async Task<OperationResult<IEnumerable<ProductDTO>>> GetAllNewProductsAsync()
        {
           
            IEnumerable<Product> productList = await productRepository.GetAllNew();
            Message message = new Message(string.Empty, "Return Successfully");
            List<ProductDTO> productDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            return new OperationResult<IEnumerable<ProductDTO>>(productDTOList, true, message);
        }

        public async Task<OperationResult<IEnumerable<ProductDTO>>> GetAllPopularProductsAsync()
        {
            IEnumerable<Product> productList = await productRepository.GetAllPopular();
            Message message = new Message(string.Empty, "Return Successfully");
            List<ProductDTO> productDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            return new OperationResult<IEnumerable<ProductDTO>>(productDTOList, true, message);
        }

        public async Task<OperationResult<IEnumerable<ProductDTO>>> GetAllBestsellerProductsAsync()
        {
            IEnumerable<Product> productList = await productRepository.GetAllBestselling();
            Message message = new Message(string.Empty, "Return Successfully");
            List<ProductDTO> productDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            return new OperationResult<IEnumerable<ProductDTO>>(productDTOList, true, message);
        }

        public async Task<OperationResult<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {

            Product product = mapper.Map<ProductDTO, Product>(productDTO);
            product.IsActive = true;
            await mongoUnitOfWork.MongoDBRepository.Add(product);
            Message message = new Message(string.Empty, "Inserted Successfully");
            return new OperationResult<ProductDTO>(productDTO, true, message);
        }

        public async Task<OperationResult<IEnumerable<ProductDTO>>> DeleteAsync(string id)
        {
            IEnumerable<Product> productList = await mongoUnitOfWork.MongoDBRepository.GetById(id);
            if (productList.ToList().Count > 0)
            {
                Message message = new Message(string.Empty, "Deleted Successfully");
                List<ProductDTO> productDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
                await mongoUnitOfWork.MongoDBRepository.Delete(id);
                return new OperationResult<IEnumerable<ProductDTO>>(productDTOList, true, message);

            }
            else
            {
                return new OperationResult<IEnumerable<ProductDTO>>(new List<ProductDTO>(), false, new Message(String.Empty, "Error in deleting"));
            }
        }
    }
}
