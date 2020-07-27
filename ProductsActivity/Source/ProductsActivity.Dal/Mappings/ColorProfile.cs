using AutoMapper;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Mappings
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>();

            CreateMap<ColorDto, Color>();
        }
    }
}
