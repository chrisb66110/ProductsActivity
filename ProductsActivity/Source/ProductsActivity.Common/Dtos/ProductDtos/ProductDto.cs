using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ProductsActivity.Common.Dtos.ProductLikeDtos;

namespace ProductsActivity.Common.Dtos.ProductDtos
{
    [ExcludeFromCodeCoverage]
    public class ProductDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOld { get; set; }
        public bool IncludeShipping { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        
        public List<ProductSizeDto> ProductsSizes { get; set; }
        public List<ProductColorDto> ProductsColors { get; set; }
        public List<ImageDto> Images { get; set; }

        public List<ProductLikeDto> Likes { get; set; }
        
        public long ProductViewedId { get; set; }
    }
}
