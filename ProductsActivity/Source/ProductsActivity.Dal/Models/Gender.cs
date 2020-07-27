using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace ProductsActivity.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class Gender : BaseEntity<long>
    {
        [Required] public string Code { get; set; }
        [Required] public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
