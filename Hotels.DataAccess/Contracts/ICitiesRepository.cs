using Hotels.Models.Dtos.City;
using Hotels.Models.Models;

namespace Hotels.DataAccess.Contracts;

public interface ICitiesRepository : IGenericRepository<City>
{
    Task<CityDto> GetDetails(int id);
}
