using AutoMapper;
using Hotels.API.Services;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using Hotels.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotels.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IRoomsRepository _roomsRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public BookingController(DataContext context, IRoomsRepository roomsRepository, IMapper mapper, ICurrentUserService currentUserService)
    {
        _roomsRepository = roomsRepository;
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    private string GetUserId() => _currentUserService?.UserId!;
    private string GetUserRole() => _currentUserService?.UserRole!;

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        var bookings = GetUserRole().Equals("Administrator") ? await _context.Bookings.ToListAsync() : await _context.Bookings.Where(c => c.UserId == GetUserId()).ToListAsync();
        return bookings;
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        var booking = GetUserRole().Equals("Administrator") ? await _context.Bookings.FindAsync(id) : await _context.Bookings.FirstOrDefaultAsync(c => c.Id == id && c.UserId == GetUserId());
        if (booking is null) return NotFound();
        return booking;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutBooking(int id, Booking booking)
    {
        if (id != booking.Id)
            return BadRequest();

        _context.Entry(booking).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookingExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    //[HttpPost]
    //[Authorize]
    //public async Task<ActionResult<Booking>> PostBooking(BookingRequest booking)
    //{
    //    var requestedRoom = await _roomsRepository.GetDetails(booking.RoomId);
    //    if (requestedRoom.IsAvailable is false)
    //        return Ok(new { failed = "The room you are looking for is already booked." });

    //    requestedRoom.IsAvailable = false;
    //    var updateRequestedRoom = _mapper.Map<Room>(requestedRoom);
    //    await _roomsRepository.UpdateAsync(updateRequestedRoom);

    //    var createBooking = _mapper.Map<Booking>(booking);
    //    createBooking.UserId = _currentUserService?.UserId ?? string.Empty;
    //    await _context.Bookings.AddAsync(createBooking);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetBooking", new { id = createBooking.Id }, booking);
    //}

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Booking>> PostBooking(BookingRequest booking)
    {
        await CheckRoomAvailableStatus(booking.RoomId);
        var requestedRoom = await _context.Rooms.FindAsync(booking.RoomId);
        if (requestedRoom!.IsAvailable is false)
            return Ok(new { failed = "The room you are looking for is already booked." });

        requestedRoom.IsAvailable = false;
        var updateRequestedRoom = _mapper.Map<Room>(requestedRoom);
        await _roomsRepository.UpdateAsync(updateRequestedRoom);

        var createBooking = _mapper.Map<Booking>(booking);
        createBooking.UserId = _currentUserService?.UserId ?? string.Empty;
        await _context.Bookings.AddAsync(createBooking);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBooking", new { id = createBooking.Id }, booking);
    }

    [HttpDelete("{id}")]
    [Authorize]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking is null) return NotFound();

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BookingExists(int id)
    {
        return (_context.Bookings?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    private async Task CheckRoomAvailableStatus(int roomId)
    {
        var room = await _roomsRepository.GetDetails(roomId);
        if (room.IsAvailable == false && room.CheckOut.Date < DateTime.Now.Date)
        {
            room.IsAvailable = true;
            room.CheckOut = DateTime.Now.Date;
            var model = _context.Entry(_mapper.Map<Room>(room));
            model.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
