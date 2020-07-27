using System;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Common.Dtos.ProductViewedDtos
{
    [ExcludeFromCodeCoverage]
    public class ProductViewedDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Username { get; set; }
        public DateTime DateTimeInitial { get; set; }
        public TimeSpan TimeViewed { get; set; }
    }
}
