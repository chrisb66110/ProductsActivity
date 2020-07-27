using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Responses.ProductResponses
{
    [ExcludeFromCodeCoverage]
    public class ImageResponse
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Url { get; set; }

        public List<ImageLikeResponse> Likes { get; set; }
    }
}
