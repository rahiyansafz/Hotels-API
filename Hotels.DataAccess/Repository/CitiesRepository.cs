using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Hotels.Models.Dtos.City;
using Hotels.Models.Exceptions;
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

    public async Task<CityDto> GetDetails(int id)
    {
        //return await _context.Cities.Include(q => q.Hotels)
        //    .FirstOrDefaultAsync(q => q.Id == id);

        var city = await _context.Cities.Include(q => q.Hotels)
                .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

        if (city is null)
            throw new NotFoundException(nameof(GetDetails), id);

        return city;
    }
}
