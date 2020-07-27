using AutoMapper;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Mappings
{
    public class AgeGroupProfile : Profile
    {
        public AgeGroupProfile()
        {
            CreateMap<AgeGroup, AgeGroupDto>();

            CreateMap<AgeGroupDto, AgeGroup>();
        }
    }
}
