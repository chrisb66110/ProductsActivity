using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Contexts
{
    [ExcludeFromCodeCoverage]
    public class CatalogueContext : DbContext
    {
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public CatalogueContext(DbContextOptions<CatalogueContext> options) : base(options) { }
    }
}
