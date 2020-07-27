using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class ImageLikeRequest
    {
        [Required] public long Id { get; set; }
        [Required] public long ProductId { get; set; }
        [Required] public string Url { get; set; }
        [Required] public string Username { get; set; }
        [Required] public DateTime DateTime { get; set; }
        [Required] public long ImageId { get; set; }
    }
}
