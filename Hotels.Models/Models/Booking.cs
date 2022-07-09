using Hotels.Models.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Models;

public class Booking
{
    public int Id { get; set; }
    [ForeignKey(nameof(HotelId))] public int HotelId { get; set; }
    [NotMapped] public virtual Hotel Hotel { get; set; }
    [ForeignKey(nameof(RoomId))] public int RoomId { get; set; }
    [NotMapped] public virtual Room Room { get; set; }
    public string UserId { get; set; }
    [NotMapped] public virtual User User { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
}
