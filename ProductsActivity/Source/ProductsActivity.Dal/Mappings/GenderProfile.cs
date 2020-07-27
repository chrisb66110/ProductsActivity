using AutoMapper;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Mappings
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>();

            CreateMap<GenderDto, Gender>();
        }
    }
}
