using Hotels.Models.Models;

namespace Hotels.Models.Dtos.Room;

public class GetRoomDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public RoomType Type { get; set; } = RoomType.Single;
    public bool IsAvailable { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string DisplayPrice { get; set; } = string.Empty;
    public double DisplayPriceRaw { get; set; }
    public int MaxOccupancies { get; set; }
    public int BedCount { get; set; }
    public int BathroomCount { get; set; }
    public bool IsBooked { get; set; }
    public bool IsFavourite { get; set; }
    public double ServiceCharge { get; set; }
    public string DiscountedPrice { get; set; } = string.Empty;
    public int HotelId { get; set; }
}
