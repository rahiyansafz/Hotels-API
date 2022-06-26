using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;

namespace Hotels.DataAccess.Repository;

public class AmenitiesRepository : GenericRepository<Amenity>, IAmenitiesRepository
{
    public AmenitiesRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
