using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;

namespace WilliMaps.Data
{
    public class WilliMapsDbContextFactory : IDesignTimeDbContextFactory<WilliMapsDbContext>
    {
        public WilliMapsDbContext CreateDbContext(string[] args)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(
                "Host=localhost;Port=5433;Database=willimaps;Username=willimaps;Password=root"
            );
            dataSourceBuilder.UseNetTopologySuite();
            var dataSource = dataSourceBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<WilliMapsDbContext>();
            optionsBuilder.UseNpgsql(dataSource, o => o.UseNetTopologySuite()); // ← hier auch

            return new WilliMapsDbContext(optionsBuilder.Options);
        }
    }
}