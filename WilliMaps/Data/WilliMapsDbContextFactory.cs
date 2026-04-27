using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace WilliMaps.Data
{
    public class WilliMapsDbContextFactory : IDesignTimeDbContextFactory<WilliMapsDbContext>
    {
        public WilliMapsDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true) 
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            dataSourceBuilder.UseNetTopologySuite();
            var dataSource = dataSourceBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<WilliMapsDbContext>();
            optionsBuilder.UseNpgsql(dataSource, o => o.UseNetTopologySuite());

            return new WilliMapsDbContext(optionsBuilder.Options);
        }
    }
}