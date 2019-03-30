using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmCart.Core.ValueObjects;
using AmCart.ProductModule.AppServices;
using AmCart.ProductModule.AppServices.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmCart.ProductModule.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagGroupController : ControllerBase
    {
        private ITagGroupAppService tagGroupAppService;
        private IMapper mapper;

        public TagGroupController(ITagGroupAppService tagGroupAppService, IMapper mapper)
        {
            this.tagGroupAppService = tagGroupAppService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<OperationResult<IEnumerable<TagGroupDTO>>> GetAllCategoriesAsync()
        {
            return await tagGroupAppService.GetAllTagGroupAsync();
        }

        [HttpPost]
        public async Task<OperationResult<TagGroupDTO>> Create(TagGroupDTO tagGroupDTO)
        {
            return await tagGroupAppService.CreateAsync(tagGroupDTO);
        }

        [HttpPut]
        public async Task<OperationResult<TagGroupDTO>> Update(TagGroupDTO tagGroupDTO)
        {
            return await tagGroupAppService.UpdateAsync(tagGroupDTO);
        }

        [HttpDelete]
        public async Task<OperationResult<IEnumerable<TagGroupDTO>>> Delete(string id)
        {
            return await tagGroupAppService.DeleteAsync(id);
        }
    }
}