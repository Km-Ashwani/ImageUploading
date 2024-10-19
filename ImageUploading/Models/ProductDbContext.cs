using Microsoft.EntityFrameworkCore;

namespace ImageUploading.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>  option) :base(option)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
