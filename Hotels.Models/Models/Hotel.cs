using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Models;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int RoomCount { get; set; }
    public double Rating { get; set; }
    public double MinPrice { get; set; }
    public double MaxPrice { get; set; }
    public int Occupancies { get; set; }

    [ForeignKey(nameof(CityId))]
    public int CityId { get; set; }
    public City City { get; set; }

    public virtual IEnumerable<Room>? Rooms { get; set; }
    public virtual IEnumerable<Facility>? Facilities { get; set; }

}
