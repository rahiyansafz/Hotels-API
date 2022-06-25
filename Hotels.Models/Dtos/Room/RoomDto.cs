using Hotels.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Dtos.Room;

public class RoomDto : BaseRoomDto, IBase
{
    public int Id { get; set; }
    public IEnumerable<Amenity> Amenities { get; set; }

}
