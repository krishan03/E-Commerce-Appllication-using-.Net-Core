using AmCart.CustomerModule.AppService.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.CustomerModule.AppService.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() : base("MappingProfile")
        {
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<CartProductDTO, CartProduct>().ReverseMap();
            CreateMap<CustomerContextDTO, CustomerContext>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<ProductLiteDTO, ProductLite>().ReverseMap();
            CreateMap<TagGroupDTO, TagGroup>().ReverseMap();
        }
    }
}
