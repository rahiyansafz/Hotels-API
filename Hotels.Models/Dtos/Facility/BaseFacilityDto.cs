using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Dtos.Facility;

public class BaseFacilityDto
{
    [Required]
    public bool ElevatorAccess { get; set; }
    [Required]
    public bool FitnessCenter { get; set; }
    [Required]
    public bool ContactLessCheckIn { get; set; }
    [Required]
    public bool ProfessionalyClean { get; set; }
    [Required]
    public bool Support24by7 { get; set; }
    [Required]
    public bool OutdoorSpace { get; set; }
    [Required]
    public bool SwimmingPool { get; set; }
    [Required]
    public bool FreeParking { get; set; }
    [Required]
    public bool FreeWifi { get; set; }
    [Required]
    public bool LuggageStorage { get; set; }
    [Required]
    public bool IndoorGames { get; set; }
    [Required]
    public bool LoungeAndWorkSpace { get; set; }
    [Required]
    public int HotelId { get; set; }
}