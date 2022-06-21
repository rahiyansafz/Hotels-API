using Hotels.Models.Models;

namespace Hotels.DataAccess.Contracts;

public interface ICitiesRepository : IGenericRepository<City>
{
    Task<City> GetDetails(int id);
}
