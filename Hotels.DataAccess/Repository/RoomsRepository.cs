using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Hotels.Models.Dtos.Room;
using Hotels.Models.Exceptions;
using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.DataAccess.Repository;

public class RoomsRepository : GenericRepository<Room>, IRoomsRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public RoomsRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RoomDto> GetDetails(int id)
    {
        //return await _context.Rooms.Include(q => q.Amenities).FirstOrDefaultAsync(q => q.Id == id);

        var room = await _context.Rooms.Include(q => q.Amenities)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

        if (room is null)
            throw new NotFoundException(nameof(GetDetails), id);

        return room;
    }
}
