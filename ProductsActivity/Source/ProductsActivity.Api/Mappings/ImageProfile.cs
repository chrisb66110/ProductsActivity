using AutoMapper;
using ProductsActivity.Api.Responses;
using ProductsActivity.Api.Responses.ProductResponses;
using ProductsActivity.Common.Dtos.ProductDtos;

namespace ProductsActivity.Api.Mappings
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageDto, ImageResponse>();
        }
    }
}
