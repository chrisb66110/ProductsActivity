using AutoMapper;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Common.Dtos.ImageLikeDtos;

namespace ProductsActivity.Api.Mappings
{
    public class ImageLikeProfile : Profile
    {
        public ImageLikeProfile()
        {
            CreateMap<ImageLikeRequest, ImageLikeDto>();

            CreateMap<ImageLikeDto, ImageLikeResponse>();

            CreateMap<ImageLikeLogDto, ImageLikeLogResponse>();
        }
    }
}
