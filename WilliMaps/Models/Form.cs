namespace WilliMaps.Models
{
    public class Form
    {
        public int Id { get; set; }

        // FK Location
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public FormType Type { get; set; }
        public FormStatus Status { get; set; } = FormStatus.Open;


        public DateOnly SubmittedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly? ProcessedAt { get; set; }
        public string? ProcessedNote { get; set; }   

        // FK ApplicationUser
        public string? ProcessedById { get; set; }
        public ApplicationUser? ProcessedBy { get; set; }
    }
}