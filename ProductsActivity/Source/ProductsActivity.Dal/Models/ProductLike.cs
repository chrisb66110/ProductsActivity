using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace ProductsActivity.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class ProductLike : BaseEntity<long>
    {
        [Required] public long ProductId { get; set; }
        [Required] public string ProductCode { get; set; }
        [Required] public string Username { get; set; }
        [Required] public DateTime DateTime { get; set; }
    }
}
