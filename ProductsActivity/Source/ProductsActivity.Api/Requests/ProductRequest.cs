using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class ProductRequest
    {
        [Required] public long Id { get; set; }
        [Required] public string Property0 { get; set; }
        [Required] public string Property1 { get; set; }
        [Required] public string Property2 { get; set; }
        [Required] public string Property3 { get; set; }
        [Required] public string Property4 { get; set; }
        [Required] public string Property5 { get; set; }
        [Required] public string Property6 { get; set; }
        [Required] public string Property7 { get; set; }
        [Required] public string Property8 { get; set; }
        [Required] public string Property9 { get; set; }
    }
}
