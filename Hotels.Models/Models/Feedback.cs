using Hotels.Models.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Models;

public class Feedback
{
    public int Id { get; set; }
    public int RatingValue { get; set; }

    [ForeignKey(nameof(HotelId))]
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }

    [ForeignKey(nameof(UserId))]
    public int UserId { get; set; }
    public User User { get; set; }
}
