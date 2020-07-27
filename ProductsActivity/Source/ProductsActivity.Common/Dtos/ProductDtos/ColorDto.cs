using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Common.Dtos.ProductDtos
{
    [ExcludeFromCodeCoverage]
    public class ColorDto
    {
        public string Name { get; set; }
        public string RGB { get; set; }
    }
}
