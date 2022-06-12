using Microsoft.EntityFrameworkCore;
using SharpBuster.Models;

namespace SharpBuster.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieClient>()
                .HasOne(m => m.Movie)
                .WithMany(mc => mc.MovieClients)
                .HasForeignKey(mi => mi.MovieId);
            modelBuilder.Entity<MovieClient>()
                .HasOne(m => m.Client)
                .WithMany(mc => mc.MovieClients)
                .HasForeignKey(mi => mi.ClientId);
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<MovieClient> MovieClients { get; set; }
    }
}
