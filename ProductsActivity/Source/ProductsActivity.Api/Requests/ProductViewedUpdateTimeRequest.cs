using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsActivity.Api.Requests
{
    public class ProductViewedUpdateTimeRequest
    {
        [Required] public long ProductViewedId { get; set; }
    }
}
