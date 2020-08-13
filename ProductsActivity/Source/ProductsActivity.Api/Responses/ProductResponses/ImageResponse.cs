using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Responses.ProductResponses
{
    [ExcludeFromCodeCoverage]
    public class ImageResponse
    {
        public string Url { get; set; }
        public int Position { get; set; }

        public ProductResponse Product { get; set; }
    }
}
