using Microsoft.EntityFrameworkCore;
using ComicSystem.Models;

namespace ComicSystem.Data{
    public class ComicContext : DbContext{
        public ComicContext(DbContextOptions<ComicContext> options):base(options){}
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<ComicBooks> ComicBooks { get; set; }
        public DbSet<RentalDetails> RentalDetails { get; set; }

    }
}