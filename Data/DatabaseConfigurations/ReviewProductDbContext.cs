using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Review.API.DatabaseConfigurations
{
    public class ReviewProductDbContext : DbContext
    {
        public ReviewProductDbContext(DbContextOptions<ReviewProductDbContext> options) : base(options)
        {

        }
        public DbSet<ReviewModel> Review { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<User> User { get; set; }
    }
}
