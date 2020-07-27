using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace ProductsActivity.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class Color : BaseEntity<long>
    {
        [Required] public string Name { get; set; }
        [Required] public string RGB { get; set; }

        public List<ProductColor> ProductsColors { get; set; }
    }
}
