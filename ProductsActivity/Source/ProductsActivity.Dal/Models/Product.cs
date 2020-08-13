using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace ProductsActivity.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class Product : BaseEntity<long>
    {
        [Required] public string Title { get; set; }
        [Required] public long? CategoryId { get; set; }
        [Required] public string Code { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public decimal PriceOld { get; set; }
        [Required] public bool IncludeShipping { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string MainImage { get; set; }
        [Required] public bool Active { get; set; }

        public Category Category { get; set; }
        
        public List<ProductSize> ProductsSizes { get; set; }
        public List<ProductColor> ProductsColors { get; set; }
        public List<Image> Images { get; set; }
    }
}
