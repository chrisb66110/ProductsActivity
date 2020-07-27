using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class ProductViewedRequest
    {
        [Required] public long Id { get; set; }
        [Required] public long ProductId { get; set; }
        [Required] public string ProductCode { get; set; }
        [Required] public string Username { get; set; }
        [Required] public DateTime DateTimeInitial { get; set; }
        [Required] public TimeSpan TimeViewed { get; set; }
    }
}
