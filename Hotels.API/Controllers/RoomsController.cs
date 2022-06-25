using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.Models.Dtos.Room;
using Microsoft.AspNetCore.Authorization;
using Hotels.Models.Models.Response;
using Hotels.Models.Models.QueryResponse;
using Hotels.Models.Exceptions;

namespace Hotels.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
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

    // GET: api/v1/Rooms/GetAll
    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<GetRoomDto>>> GetRooms()
    {
        var rooms = await _roomsRepository.GetAllAsync<GetRoomDto>();
        return Ok(rooms);
    }

    // GET: api/Rooms/?StartIndex=0&pagesize=25&PageNumber=1
    [HttpGet]
    public async Task<ActionResult<PagedResult<GetRoomDto>>> GetPagedRooms([FromQuery] QueryParameters queryParameters)
    {
        var rooms = await _roomsRepository.GetAllAsync<GetRoomDto>(queryParameters);
        return Ok(rooms);
    }

    // GET: api/v1/Rooms/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDto>> GetRoom(int id)
    {
        var room = await _roomsRepository.GetDetails(id);
        return Ok(room);
    }

    // PUT: api/v1/Rooms/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutRoom(int id, UpdateRoomDto updatedRoom)
    {
        if (id != updatedRoom.Id)
            return BadRequest();

        try
        {
            await _roomsRepository.UpdateAsync(id, updatedRoom);
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

    // POST: api/v1/Rooms
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<RoomDto>> PostRoom(CreateRoomDto createRoom)
    {
        var room = await _roomsRepository.AddAsync<CreateRoomDto, GetRoomDto>(createRoom);
        return CreatedAtAction("GetRoom", new { id = room.Id }, room);
    }

    // DELETE: api/v1/Rooms/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        await _roomsRepository.DeleteAsync(id);
        return NoContent();
    }

    private async Task<bool> RoomExists(int id)
    {
        return await _roomsRepository.Exists(id);
    }
}
