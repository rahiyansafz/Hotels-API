using Hotels.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Dtos.Room;

public class BaseRoomDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public RoomType Type { get; set; } = RoomType.Single;
    [Required]
    public bool IsAvailable { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    [Required]
    public string DisplayPrice { get; set; } = string.Empty;
    [Required]
    public double DisplayPriceRaw { get; set; }
    [Required]
    public int MaxOccupancies { get; set; }
    [Required]
    public int BedCount { get; set; }
    [Required]
    public int BathroomCount { get; set; }
    [Required]
    public bool IsBooked { get; set; }
    [Required]
    public bool IsFavourite { get; set; }
    [Required]
    public double ServiceCharge { get; set; }
    [Required]
    public string DiscountedPrice { get; set; } = string.Empty;
    public int HotelId { get; set; }
}
