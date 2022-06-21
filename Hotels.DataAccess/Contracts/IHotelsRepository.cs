using Hotels.Models.Models;

namespace Hotels.DataAccess.Contracts;

public interface IHotelsRepository : IGenericRepository<Hotel>
{
    Task<Hotel> GetDetails(int id);
}
