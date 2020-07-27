using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsActivity.Dal.Models;

namespace ProductsActivity.Dal.Contexts
{
    [ExcludeFromCodeCoverage]
    public class ProductsActivityContext : DbContext
    {
        public DbSet<ImageLike> ImagesLikes { get; set; }
        public DbSet<ImageLikeLog> ImagesLikesLogs { get; set; }
        public DbSet<ProductLike> ProductsLikes { get; set; }
        public DbSet<ProductLikeLog> ProductsLikesLogs { get; set; }
        public DbSet<ProductViewed> ProductsViewed { get; set; }
        public DbSet<ProductViewedLog> ProductsViewedLogs { get; set; }
        
        public ProductsActivityContext(DbContextOptions<ProductsActivityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<ImageLike>().HasIndex(s => s.ProductId);
            modelBuilder.Entity<ImageLike>().HasIndex(s => s.ImageId);
            modelBuilder.Entity<ImageLike>().HasIndex(s => s.Username);
            
            modelBuilder.Entity<ProductLike>().HasIndex(s => s.ProductId);
            modelBuilder.Entity<ProductLike>().HasIndex(s => s.ProductCode);
            modelBuilder.Entity<ProductLike>().HasIndex(s => s.Username);
            
            modelBuilder.Entity<ProductViewed>().HasIndex(s => s.ProductId);
            modelBuilder.Entity<ProductViewed>().HasIndex(s => s.ProductCode);
            modelBuilder.Entity<ProductViewed>().HasIndex(s => s.Username);
            modelBuilder.Entity<ProductViewed>().HasIndex(s => new { s.Username, s.ProductId, s.DateTimeInitial }).IsUnique();
        }

        public async Task MigrationsAsync()
        {
            if (Database.GetPendingMigrations().AsQueryable().Any())
            {
                await Database.MigrateAsync();
            }
        }
    }
}
