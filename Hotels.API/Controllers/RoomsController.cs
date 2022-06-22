using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.Models.Dtos.Room;
using Microsoft.AspNetCore.Authorization;

namespace Hotels.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRoomsRepository _roomsRepository;

    public RoomsController(IMapper mapper, IRoomsRepository roomsRepository)
    {
        _mapper = mapper;
        _roomsRepository = roomsRepository;
    }

    // GET: api/Rooms
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetRoomDto>>> GetRooms()
    {
        var rooms = await _roomsRepository.GetAllAsync();

        if (rooms is null)
            return NotFound();

        var getRooms = _mapper.Map<List<GetRoomDto>>(rooms);

        return Ok(getRooms);
    }

    // GET: api/Rooms/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDto>> GetRoom(int id)
    {
        var room = await _roomsRepository.GetDetails(id);

        if (room is null)
            return NotFound();

        var getRoom = _mapper.Map<RoomDto>(room);

        return Ok(getRoom);
    }

    // PUT: api/Rooms/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutRoom(int id, UpdateRoomDto updatedRoom)
    {
        if (id != updatedRoom.Id)
            return BadRequest();

        //_context.Entry(room).State = EntityState.Modified;

        var room = await _roomsRepository.GetAsync(id);

        if (room is null)
            return NotFound();

        _mapper.Map(updatedRoom, room);

        try
        {
            await _roomsRepository.UpdateAsync(room);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await RoomExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/Rooms
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<Room>> PostRoom(CreateRoomDto createRoom)
    {
        var room = _mapper.Map<Room>(createRoom);

        if (room is null)
            return Problem("Entity set 'DataContext.Rooms'  is null.");

        await _roomsRepository.AddAsync(room);

        return CreatedAtAction("GetRoom", new { id = room.Id }, room);
    }

    // DELETE: api/Rooms/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _roomsRepository.GetAsync(id);

        if (room is null)
            return NotFound();

        await _roomsRepository.DeleteAsync(id);

        return NoContent();
    }

    private async Task<bool> RoomExists(int id)
    {
        return await _roomsRepository.Exists(id);
        //return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
