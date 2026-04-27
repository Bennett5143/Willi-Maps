using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using WilliMaps.Models;
using Location = WilliMaps.Models.Location;
using Npgsql;

namespace WilliMaps.Data
{
    public class WilliMapsDbContext : DbContext
    {
        public WilliMapsDbContext(DbContextOptions<WilliMapsDbContext> options)
            : base(options) { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<OpeningTime> OpeningTimes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");

            modelBuilder.Entity<Location>()
                .HasMany(l => l.Properties)
                .WithMany();

            modelBuilder.Entity<Form>()
                .Property(f => f.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Form>()
                .Property(f => f.Status)
                .HasConversion<string>();
        }
    }
}