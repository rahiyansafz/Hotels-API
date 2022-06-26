using Hotels.Models.Dtos.Facility;
using Hotels.Models.Dtos.Room;

namespace Hotels.Models.Dtos.Hotel;

public class HotelDto : BaseHotelDto, IBase
{
    public int Id { get; set; }
    public IEnumerable<GetRoomDto> Rooms { get; set; }
    public IEnumerable<FacilityDto> Facilities { get; set; }
}