using Amcart.Business.AppService.DTOs;
using Amcart.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amcart.Web.Mapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile() : base("WebMappingProfile")
        {
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
        }
    }
}
