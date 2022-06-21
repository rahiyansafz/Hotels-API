using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
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

    public async Task<Hotel> GetDetails(int id)
    {
        return await _context.Hotels.Include(q => q.Rooms)
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}
