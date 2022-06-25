using Hotels.Models.Dtos.Room;
using Hotels.Models.Models;

namespace Hotels.Models.Dtos.Hotel;

public class HotelDto : BaseHotelDto, IBase
{
    public int Id { get; set; }
    public IEnumerable<GetRoomDto> Rooms { get; set; }
    public IEnumerable<Facility> Facilities { get; set; }
}
