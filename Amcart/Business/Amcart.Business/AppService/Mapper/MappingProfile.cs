using Amcart.Business.AppService.DTOs;
using Amcart.Business.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amcart.Business.AppService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base("MappingProfile")
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
