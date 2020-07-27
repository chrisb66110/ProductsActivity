using AutoMapper;
using ProductsActivity.Common.Dtos.ProductDtos;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Mappings
{
    public class ProductColorProfile : Profile
    {
        public ProductColorProfile()
        {
            CreateMap<ProductColor, ProductColorDto>();

            CreateMap<ProductColorDto, ProductColor>();
        }
    }
}
