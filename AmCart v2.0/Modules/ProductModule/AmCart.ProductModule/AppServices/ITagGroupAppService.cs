using AmCart.Core.ValueObjects;
using AmCart.ProductModule.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.ProductModule.AppServices
{
    public interface ITagGroupAppService
    {
        Task<OperationResult<IEnumerable<TagGroupDTO>>> GetAllTagGroupAsync();
        Task<OperationResult<TagGroupDTO>> CreateAsync(TagGroupDTO tagGroupDTO);

        Task<OperationResult<TagGroupDTO>> UpdateAsync(TagGroupDTO tagGroupDTO);

        Task<OperationResult<IEnumerable<TagGroupDTO>>> DeleteAsync(string id);

        Task<OperationResult<TagGroupDTO>> GetByIdAsync(string id);

    }
}
