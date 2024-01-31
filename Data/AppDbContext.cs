using BogsyVideoStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BogsyVideoStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
