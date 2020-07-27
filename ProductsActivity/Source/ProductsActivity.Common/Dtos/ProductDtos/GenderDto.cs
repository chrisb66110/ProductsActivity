using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Common.Dtos.ProductDtos
{
    [ExcludeFromCodeCoverage]
    public class GenderDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
