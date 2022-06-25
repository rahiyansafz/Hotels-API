using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Dtos.City;

public abstract class BaseCityDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Country { get; set; } = string.Empty;
    [Required]
    public string Division { get; set; } = string.Empty;
    [Required]
    public bool IsFeatured { get; set; }
}
