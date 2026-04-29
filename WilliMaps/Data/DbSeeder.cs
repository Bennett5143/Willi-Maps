using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using WilliMaps.Models;

namespace WilliMaps.Data
{
    public class DbSeeder
    {
        private readonly WilliMapsDbContext _db;
        private readonly IPasswordHasher<ApplicationUser> _hasher;
        private readonly SeedSettings _settings;
        private readonly ILogger<DbSeeder> _logger;

        public DbSeeder(
            WilliMapsDbContext db,
            IPasswordHasher<ApplicationUser> hasher,
            IOptions<SeedSettings> settings,
            ILogger<DbSeeder> logger)
        {
            _db = db;
            _hasher = hasher;
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await SeedAdminUserAsync();
            // hier kommen später weitere Seeds hin (Kategorien, Test-Orte, …)
        }

        private async Task SeedAdminUserAsync()
        {
            if (_db.Users.Any())
            {
                _logger.LogInformation("User-Tabelle nicht leer – Seed übersprungen.");
                return;
            }

            var admin = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = _settings.AdminUserName,
                Role = "Admin",
                PasswordHash = ""
            };
            admin.PasswordHash = _hasher.HashPassword(admin, _settings.AdminPassword);

            _db.Users.Add(admin);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Admin-User '{UserName}' angelegt.", admin.UserName);
        }
    }
}
