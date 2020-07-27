using AutoMapper;
using ProductsActivity.Common.Dtos.ImageLikeDtos;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Mappings
{
    public class ImageLikeProfile : Profile
    {
        public ImageLikeProfile()
        {
            CreateMap<ImageLike, ImageLikeDto>();

            CreateMap<ImageLikeDto, ImageLike>();

            CreateMap<ImageLikeLog, ImageLikeLogDto>();
        }
    }
}
