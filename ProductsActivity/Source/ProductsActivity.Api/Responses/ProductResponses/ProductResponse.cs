using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Responses.ProductResponses
{
    [ExcludeFromCodeCoverage]
    public class ProductResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOld { get; set; }
        public bool IncludeShipping { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        
        public List<ProductSizeResponse> ProductsSizes { get; set; }
        public List<ProductColorResponse> ProductsColors { get; set; }
        public List<ImageResponse> Images { get; set; }

        public List<ProductLikeResponse> Likes { get; set; }

        public long ProductViewedId { get; set; }
    }
}
