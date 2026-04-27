using NetTopologySuite.Geometries; 

namespace WilliMaps.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Point Coordinates { get; set; } = null!;

        // FK Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // FK Address
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public List<Property> Properties { get; set; } = [];
        public List<OpeningTime> OpeningTimes { get; set; } = [];
        public List<Event> Events { get; set; } = [];
    }
}
