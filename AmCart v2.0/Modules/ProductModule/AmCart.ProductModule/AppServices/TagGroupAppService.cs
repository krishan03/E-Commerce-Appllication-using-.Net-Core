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
using System.Linq;

namespace AmCart.ProductModule.AppServices
{
    public class TagGroupAppService : AppService, ITagGroupAppService
    {
        private IMapper mapper;
        private IProductModuleUnitOfWork unitOfWork;
        private IExceptionManager exceptionManager;
        private IProductRepository productRepository;
        private ITagGroupUnitOfWork mongoUnitOfWork;


        public TagGroupAppService(IProductModuleUnitOfWork unitOfWork, ITagGroupUnitOfWork mongoUnitOfWork, IProductRepository productRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            //this.unitOfWork = unitOfWork;
            //this.exceptionManager = exceptionManager;
            this.productRepository = productRepository;
            this.mongoUnitOfWork = mongoUnitOfWork;

        }

        public async Task<OperationResult<TagGroupDTO>> CreateAsync(TagGroupDTO tagGroupDTO)
        {
            TagGroup tagGroup = mapper.Map<TagGroupDTO, TagGroup>(tagGroupDTO);
           
            await mongoUnitOfWork.MongoDBRepository.Add(tagGroup);
            Message message = new Message(string.Empty, "Inserted Successfully");
            return new OperationResult<TagGroupDTO>(tagGroupDTO, true, message);
        }

       

        public async Task<OperationResult<IEnumerable<TagGroupDTO>>> GetAllTagGroupAsync()
        {
            IEnumerable<TagGroup> tagGroupList = await mongoUnitOfWork.MongoDBRepository.GetAll();
            Message message = new Message(string.Empty, "Return Successfully");
            List<TagGroupDTO> tagGroupDTOList = mapper.Map<IEnumerable<TagGroup>, List<TagGroupDTO>>(tagGroupList);
            return new OperationResult<IEnumerable<TagGroupDTO>>(tagGroupDTOList, true, message);
        }

        public async Task<OperationResult<TagGroupDTO>> UpdateAsync(TagGroupDTO tagGroupDTO)
        {
            TagGroup tagGroup = mapper.Map<TagGroupDTO, TagGroup>(tagGroupDTO);
            await mongoUnitOfWork.MongoDBRepository.Update(tagGroup);
            Message message = new Message(string.Empty, "Updated Successfully");
            return new OperationResult<TagGroupDTO>(tagGroupDTO, true, message);
        }

        public async Task<OperationResult<IEnumerable<TagGroupDTO>>> DeleteAsync(string id)
        {
            IEnumerable<TagGroup> tagGroupList = await mongoUnitOfWork.MongoDBRepository.GetById(id);
            if (tagGroupList.ToList().Count > 0)
            {
                Message message = new Message(string.Empty, "Deleted Successfully");
                List<TagGroupDTO> tagGroupDTOList = mapper.Map<IEnumerable<TagGroup>, List<TagGroupDTO>>(tagGroupList);
                await mongoUnitOfWork.MongoDBRepository.Delete(id);
                return new OperationResult<IEnumerable<TagGroupDTO>>(tagGroupDTOList, true, message);

            }
            else
            {
                return new OperationResult<IEnumerable<TagGroupDTO>>(new List<TagGroupDTO>(), false, new Message(String.Empty, "Error in deleting"));
            }
        }
    }
}
