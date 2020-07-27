using AutoMapper;
using ProductsActivity.Api.Requests;
using ProductsActivity.Api.Responses;
using ProductsActivity.Common.Dtos.ProductViewedDtos;

namespace ProductsActivity.Api.Mappings
{
    public class ProductViewedProfile : Profile
    {
        public ProductViewedProfile()
        {
            CreateMap<ProductViewedRequest, ProductViewedDto>();

            CreateMap<ProductViewedDto, ProductViewedResponse>();

            CreateMap<ProductViewedLogDto, ProductViewedLogResponse>();
        }
    }
}
