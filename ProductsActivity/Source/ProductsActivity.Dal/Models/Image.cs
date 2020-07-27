using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace ProductsActivity.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class Image : BaseEntity<long>
    {
        [Required] public long ProductId { get; set; }
        [Required] public string Url { get; set; }
        [Required] public bool Active { get; set; }

        public Product Product { get; set; }
    }
}
