using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using WilliMaps.Models;
using WilliMaps.Models.Enums;
using Location = WilliMaps.Models.Location;

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
            .WithMany()
            .UsingEntity(j => j.HasData(
                new { LocationId = 1, PropertiesId = 1 },
                new { LocationId = 1, PropertiesId = 3 },
                new { LocationId = 2, PropertiesId = 1 },
                new { LocationId = 2, PropertiesId = 2 },
                new { LocationId = 2, PropertiesId = 4 },
                new { LocationId = 3, PropertiesId = 1 },
                new { LocationId = 3, PropertiesId = 4 },
                new { LocationId = 4, PropertiesId = 1 },
                new { LocationId = 4, PropertiesId = 3 },
                new { LocationId = 5, PropertiesId = 1 },
                new { LocationId = 5, PropertiesId = 2 },
                new { LocationId = 5, PropertiesId = 4 }
            ));

            modelBuilder.Entity<Form>()
                .Property(f => f.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Form>()
                .Property(f => f.Status)
                .HasConversion<string>();

            // Seed Kategorien
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Jugendzentrum", ColorHex = "#FF5733" },
                new Category { Id = 2, Name = "Bücherhalle", ColorHex = "#3380FF" },
                new Category { Id = 3, Name = "Sportverein", ColorHex = "#33FF57" },
                new Category { Id = 4, Name = "Selbstorganisierter Raum", ColorHex = "#FF33F5" }
            );

            // Seed Eigenschaften
            modelBuilder.Entity<Property>().HasData(
                new Property { Id = 1, Name = "Kostenfrei", ColorHex = "#00C853" },
                new Property { Id = 2, Name = "Barrierefrei", ColorHex = "#2196F3" },
                new Property { Id = 3, Name = "Altersgerecht", ColorHex = "#FF9800" },
                new Property { Id = 4, Name = "Für alle Geschlechter", ColorHex = "#9C27B0" }
            );

            // Seed Adressen
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "Vogelhüttendeich 55", ZipCode = "21107", City = "Hamburg" },
                new Address { Id = 2, Street = "Rotenhäuser Straße 67", ZipCode = "21107", City = "Hamburg" },
                new Address { Id = 3, Street = "Mengestraße 20", ZipCode = "21107", City = "Hamburg" },
                new Address { Id = 4, Street = "Dresdner Straße 36", ZipCode = "21107", City = "Hamburg" },
                new Address { Id = 5, Street = "Ernst-August-Straße 13", ZipCode = "21107", City = "Hamburg" }
            );

            // Seed Locations
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "Jugendzentrum Wilhelmsburg",
                    Description = "Offenes Jugendzentrum mit Freizeitangeboten für Jugendliche",
                    CategoryId = 1,
                    AddressId = 1,
                    Coordinates = new Point(10.0014, 53.4965) { SRID = 4326 }
                },
                new Location
                {
                    Id = 2,
                    Name = "Bücherhalle Wilhelmsburg",
                    Description = "Öffentliche Bücherhalle mit Lese- und Aufenthaltsbereich",
                    CategoryId = 2,
                    AddressId = 2,
                    Coordinates = new Point(10.0089, 53.4953) { SRID = 4326 }
                },
                new Location
                {
                    Id = 3,
                    Name = "Kulturpalast Wilhelmsburg",
                    Description = "Kulturzentrum mit selbstorganisierten Angeboten für alle",
                    CategoryId = 4,
                    AddressId = 3,
                    Coordinates = new Point(10.0035, 53.4947) { SRID = 4326 }
                },
                new Location
                {
                    Id = 4,
                    Name = "FC Wilhelmsburg",
                    Description = "Lokaler Fußballverein mit offenen Trainingsangeboten",
                    CategoryId = 3,
                    AddressId = 4,
                    Coordinates = new Point(10.0056, 53.4981) { SRID = 4326 }
                },
                new Location
                {
                    Id = 5,
                    Name = "Inselpark Wilhelmsburg",
                    Description = "Weitläufiger Park mit kostenlosen Sport- und Freizeitflächen",
                    CategoryId = 3,
                    AddressId = 5,
                    Coordinates = new Point(9.9934, 53.4932) { SRID = 4326 }
                }
            );
        }
    }
}