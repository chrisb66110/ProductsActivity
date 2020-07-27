using System;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Common.Dtos.ProductLikeDtos
{
    [ExcludeFromCodeCoverage]
    public class ProductLikeDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Username { get; set; }
        public DateTime DateTime { get; set; }
    }
}
