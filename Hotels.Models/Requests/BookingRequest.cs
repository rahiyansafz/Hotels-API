namespace Hotels.Models.Requests;

public class BookingRequest
{
    public int RoomId { get; set; }
    public int HotelId { get; set; }
    public DateTime CheckOut { get; set; }
    public DateTime CheckIn { get; set; }
}