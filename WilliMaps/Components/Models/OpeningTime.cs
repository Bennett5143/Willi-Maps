namespace WilliMaps.Components.Models
{
    public class OpeningTime
    {
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly OpensAt {  get; set; }

        public TimeOnly ClosesAt { get; set; }
    }
}
