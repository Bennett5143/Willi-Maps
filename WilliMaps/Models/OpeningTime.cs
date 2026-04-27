namespace WilliMaps.Models
{
    public class OpeningTime
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; } 
        public TimeOnly OpensAt {  get; set; }
        public TimeOnly ClosesAt { get; set; }

        // FK
        public int LocationId { get; set; } 
        public Location Location { get; set; }= null!;
    }
}
