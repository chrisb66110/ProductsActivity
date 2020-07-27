using AutoMapper;
using ProductsActivity.Common.Dtos.ProductLikeDtos;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Mappings
{
    public class ProductLikeProfile : Profile
    {
        public ProductLikeProfile()
        {
            CreateMap<ProductLike, ProductLikeDto>();

            CreateMap<ProductLikeDto, ProductLike>();

            CreateMap<ProductLikeLog, ProductLikeLogDto>();
        }
    }
}
