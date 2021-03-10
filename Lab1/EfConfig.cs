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
            }

            public DbSet<User> Users { get; set; }
            public DbSet<Station> Stations { get; set; }
            public DbSet<Stoppage> Stoppages { get; set; }
            public DbSet<Train> Trains { get; set; }
            public DbSet<Route> Routes { get; set; }
            public DbSet<Ticket> Tickets { get; set; }
        }
    }
}