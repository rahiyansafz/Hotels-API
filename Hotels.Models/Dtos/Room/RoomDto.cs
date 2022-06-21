using Hotels.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Dtos.Room;

public class RoomDto : BaseRoomDto
{
    public int Id { get; set; }
}
