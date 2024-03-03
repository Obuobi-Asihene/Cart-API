using CartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CartAPI.Data
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Item)
                .WithOne(i => i.Cart)
                .HasForeignKey<Cart>(c => c.ItemId);
        }
    }
}
