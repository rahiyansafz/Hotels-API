using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Dtos.Hotel;

public class BaseHotelDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public int RoomCount { get; set; }
    [Required]
    public double Rating { get; set; }
    [Required]
    public double MinPrice { get; set; }
    [Required]
    public double MaxPrice { get; set; }
    [Required]
    public int Occupancies { get; set; }
    [Required]
    public int CityId { get; set; }
}
