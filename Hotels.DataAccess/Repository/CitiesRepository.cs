using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.DataAccess.Repository;

public class CitiesRepository : GenericRepository<City>, ICitiesRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CitiesRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<City> GetDetails(int id)
    {
        return await _context.Cities.Include(q => q.Hotels)
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}
