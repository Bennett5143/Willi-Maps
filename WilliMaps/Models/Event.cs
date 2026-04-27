namespace WilliMaps.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // FK Location
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
    }
}
