using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ProductsActivity.Common.Dtos.ImageLikeDtos;

namespace ProductsActivity.Common.Dtos.ProductDtos
{
    [ExcludeFromCodeCoverage]
    public class ImageDto
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public int Position { get; set; }

        public ProductDto Product { get; set; }

        public List<ImageLikeDto> Likes { get; set; }
    }
}
