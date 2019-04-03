using AmCart.OrderModule.AppServices.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.AppServices.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base("MappingProfile")
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
            
        }
    }
}
