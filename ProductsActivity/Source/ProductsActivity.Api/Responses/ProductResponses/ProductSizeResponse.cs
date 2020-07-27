using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Responses.ProductResponses
{
    [ExcludeFromCodeCoverage]
    public class ProductSizeResponse
    {
        public long QuantityAvailable { get; set; }

        public SizeResponse Size { get; set; }
    }
}
