using AutoMapper;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Mappings
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>();

            CreateMap<ImageDto, Image>();
        }
    }
}
