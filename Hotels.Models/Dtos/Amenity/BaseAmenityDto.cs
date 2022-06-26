using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Models.Dtos.Amenity;

public class BaseAmenityDto
{
    public bool KingBedCount { get; set; }
    public bool QueenBedCount { get; set; }
    public bool SofaBedCount { get; set; }
    public bool Dishwasher { get; set; }
    public bool Microwave { get; set; }
    public bool ElectricKettle { get; set; }
    public bool IroningSet { get; set; }
    public bool AirConditioning { get; set; }
    public bool Television { get; set; }
    public bool FreeWifi { get; set; }
    public bool InSuiteLaundry { get; set; }
    public bool StreamingDevice { get; set; }
    public bool StockedKitchen { get; set; }
    public bool MountainOrHillView { get; set; }
    public bool NonSmokingRoom { get; set; }
    [Required]
    public int RoomId { get; set; }
}
