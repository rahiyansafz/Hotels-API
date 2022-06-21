using Hotels.Models.Dtos.Room;

namespace Hotels.Models.Dtos.Hotel;

public class HotelDto : BaseHotelDto
{
    public int Id { get; set; }
    public IEnumerable<GetRoomDto> Rooms { get; set; }
}
