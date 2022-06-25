using Hotels.Models.Models;

namespace Hotels.Models.Dtos.Room;

public class GetRoomDto : BaseRoomDto, IBase
{
    public int Id { get; set; }
}
