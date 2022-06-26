using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Dtos.Facility;

public class BaseFacilityDto
{
    public bool ElevatorAccess { get; set; }
    public bool FitnessCenter { get; set; }
    public bool ContactLessCheckIn { get; set; }
    public bool ProfessionalyClean { get; set; }
    public bool Support24by7 { get; set; }
    public bool OutdoorSpace { get; set; }
    public bool SwimmingPool { get; set; }
    public bool FreeParking { get; set; }
    public bool FreeWifi { get; set; }
    public bool LuggageStorage { get; set; }
    public bool IndoorGames { get; set; }
    public bool LoungeAndWorkSpace { get; set; }
    [Required]
    public int HotelId { get; set; }
}