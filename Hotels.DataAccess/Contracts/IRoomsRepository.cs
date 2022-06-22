using Hotels.Models.Models;

namespace Hotels.DataAccess.Contracts;

public interface IRoomsRepository : IGenericRepository<Room>
{
    Task<Room> GetDetails(int id);

}
