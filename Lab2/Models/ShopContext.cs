using Microsoft.EntityFrameworkCore;

namespace Lab2.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        public ShopContext(DbContextOptions options) : base(options)
        {

        }
    }
}
