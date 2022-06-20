using Hotels.Models.Dtos.Room;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Dtos.Hotel;

public class HotelDto
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
    public int CityId { get; set; }

    public IEnumerable<RoomDto> Rooms { get; set; }
}
