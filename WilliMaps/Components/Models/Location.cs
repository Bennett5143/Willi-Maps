using System.Drawing;

namespace WilliMaps.Components.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Point Coordinates { get; set; }

        public string Category { get; set; }

        public List<Property> Properties { get; set; }

        public List<OpeningTime> OpeningTimes { get; set; }


    }
}
