using Lab1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab1
{
    public class EfConfig
    {
        
        public class MyDbContext : DbContext
        {
            public MyDbContext(DbContextOptions options) : base(options) {}

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

   
                modelBuilder.Entity<Product>()
                    .HasOne(s => s.Category)
                    .WithMany(s => s.Products);

                modelBuilder.Entity<Order>()
                   .HasOne(s => s.Client)
                   .WithMany(s => s.Orders);

            }

            public DbSet<User> Users { get; set; }

            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Order> Orders { get; set; }
        }
    }
}