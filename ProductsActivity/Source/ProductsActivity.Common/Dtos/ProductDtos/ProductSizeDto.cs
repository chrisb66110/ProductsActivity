using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Common.Dtos.ProductDtos
{
    [ExcludeFromCodeCoverage]
    public class ProductSizeDto
    {
        public long QuantityAvailable { get; set; }

        public SizeDto Size { get; set; }
    }
}
