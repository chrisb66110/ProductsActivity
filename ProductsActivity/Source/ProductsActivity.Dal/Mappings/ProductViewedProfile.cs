using AutoMapper;
using ProductsActivity.Common.Dtos.ProductViewedDtos;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Mappings
{
    public class ProductViewedProfile : Profile
    {
        public ProductViewedProfile()
        {
            CreateMap<ProductViewed, ProductViewedDto>();

            CreateMap<ProductViewedDto, ProductViewed>();

            CreateMap<ProductViewedLog, ProductViewedLogDto>();
        }
    }
}
