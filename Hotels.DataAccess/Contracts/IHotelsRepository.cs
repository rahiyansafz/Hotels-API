using Hotels.Models.Dtos.Hotel;
using Hotels.Models.Models;

namespace Hotels.DataAccess.Contracts;

public interface IHotelsRepository : IGenericRepository<Hotel>
{
    Task<HotelDto> GetDetails(int id);
}
