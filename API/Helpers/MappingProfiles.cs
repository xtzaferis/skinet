using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, option => option.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, option => option.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, option => option.MapFrom<ProductUrlResolver>());
        }
    }
}