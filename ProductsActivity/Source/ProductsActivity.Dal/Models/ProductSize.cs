using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace ProductsActivity.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class ProductSize : BaseEntity<long>
    {
        [Required] public long ProductId { get; set; }
        [Required] public long SizeId { get; set; }
        [Required] public long QuantityAvailable { get; set; }

        public Product Product { get; set; }
        public Size Size { get; set; }
    }
}
