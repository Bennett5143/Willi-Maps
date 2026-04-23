using System.Runtime.Serialization.Formatters;

namespace WilliMaps.Components.Models
{
    public class Form
    {
        public int Id { get; set; }


        public Location Location { get; set; }

        public FormType Type { get; set; }

        public Status FormStatus { get; set; }

        public DateOnly SubmittedAt { get; set; }

        public DateOnly ProcessedAt { get; set; }

        public string ProcessedNote { get; set; }   

        public ApplicationUser ProcessedBy { get; set; }
    }
}