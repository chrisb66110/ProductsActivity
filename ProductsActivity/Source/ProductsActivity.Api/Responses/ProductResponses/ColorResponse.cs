using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Responses.ProductResponses
{
    [ExcludeFromCodeCoverage]
    public class ColorResponse
    {
        public string Name { get; set; }
        public string RGB { get; set; }
    }
}
