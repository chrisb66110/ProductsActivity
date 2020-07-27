using System.ComponentModel.DataAnnotations;

namespace ProductsActivity.Api.Requests
{
    public class ProductsToGridRequest
    {
        [Required] public long LastRead { get; set; }
    }
}
