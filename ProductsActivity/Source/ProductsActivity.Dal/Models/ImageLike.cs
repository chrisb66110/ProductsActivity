using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace ProductsActivity.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class ImageLike : BaseEntity<long>
    {
        [Required] public long ProductId { get; set; }
        [Required] public string Url { get; set; }
        [Required] public string Username { get; set; }
        [Required] public DateTime DateTime { get; set; }
        [Required] public long ImageId { get; set; }
    }
}
