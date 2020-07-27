using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace ProductsActivity.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class ProductColor : BaseEntity<long>
    {
        [Required] public long ProductId { get; set; }
        [Required] public long ColorId { get; set; }

        public Product Product { get; set; }
        public Color Color { get; set; }
    }
}
