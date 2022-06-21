using Hotels.Models.Dtos.Room;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Dtos.Hotel;

public class HotelDto : BaseHotelDto
{
    public int Id { get; set; }
    public IEnumerable<RoomDto> Rooms { get; set; }
}
