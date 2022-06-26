using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;

namespace Hotels.DataAccess.Repository;

public class FacilitiesRepository : GenericRepository<Facility>, IFacilitiesRepository
{
    public FacilitiesRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
