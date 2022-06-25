using Hotels.Models.Dtos.Room;
using Hotels.Models.Models;

namespace Hotels.DataAccess.Contracts;

public interface IRoomsRepository : IGenericRepository<Room>
{
    Task<RoomDto> GetDetails(int id);
}
