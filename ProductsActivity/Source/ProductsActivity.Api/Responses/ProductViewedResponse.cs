using System;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Responses
{
    [ExcludeFromCodeCoverage]
    public class ProductViewedResponse
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Username { get; set; }
        public DateTime DateTimeInitial { get; set; }
        public TimeSpan TimeViewed { get; set; }
    }
}
