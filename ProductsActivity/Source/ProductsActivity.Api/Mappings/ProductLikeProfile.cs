using AutoMapper;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Common.Dtos.ProductLikeDtos;

namespace ProductsActivity.Api.Mappings
{
    public class ProductLikeProfile : Profile
    {
        public ProductLikeProfile()
        {
            CreateMap<ProductLikeRequest, ProductLikeDto>();

            CreateMap<ProductLikeDto, ProductLikeResponse>();

            CreateMap<ProductLikeLogDto, ProductLikeLogResponse>();
        }
    }
}
