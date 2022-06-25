using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Hotels.Models.Dtos.Hotel;
using Hotels.Models.Exceptions;
using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.DataAccess.Repository;

public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public HotelsRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<HotelDto> GetDetails(int id)
    {
        var hotel = await _context.Hotels.Include(q => q.Rooms).Include(q => q.Facilities)
        .ProjectTo<HotelDto>(_mapper.ConfigurationProvider)
        .FirstOrDefaultAsync(q => q.Id == id);

        if (hotel is null)
            throw new NotFoundException(nameof(GetDetails), id);

        return hotel;
    }
}
