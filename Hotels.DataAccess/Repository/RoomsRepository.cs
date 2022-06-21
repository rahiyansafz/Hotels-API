using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;

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
}
