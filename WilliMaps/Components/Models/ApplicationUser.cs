namespace WilliMaps.Components.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; }

    }
}
