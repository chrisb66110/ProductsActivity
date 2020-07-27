using AutoMapper;
using ProductsActivity.Api.Responses;
using ProductsActivity.Api.Responses.ProductResponses;
using ProductsActivity.Common.Dtos.ProductDtos;

namespace ProductsActivity.Api.Mappings
{
    public class ProductGirdProfile : Profile
    {
        public ProductGirdProfile()
        {
            CreateMap<ProductGirdDto, ProductGirdResponse>();
        }
    }
}
