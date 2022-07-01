using Hotels.Models.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Models;

public class Booking
{
    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }

    [ForeignKey(nameof(HotelId))]
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }

    [ForeignKey(nameof(RoomId))]
    public int RoomId { get; set; }
    public Room Room { get; set; }

    [ForeignKey(nameof(UserId))]
    public int UserId { get; set; }
    public User User { get; set; }
}
