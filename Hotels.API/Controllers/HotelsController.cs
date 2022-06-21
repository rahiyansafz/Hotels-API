using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.Models.Dtos.Hotel;

namespace Hotels.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IHotelsRepository _hotelsRepository;

    public HotelsController(IMapper mapper, IHotelsRepository hotelsRepository)
    {
        _mapper = mapper;
        _hotelsRepository = hotelsRepository;
    }

    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetHotelDto>>> GetHotels()
    {
        var hotels = await _hotelsRepository.GetAllAsync();

        if (hotels is null)
            return NotFound();

        var getHotels = _mapper.Map<List<GetHotelDto>>(hotels);

        return Ok(getHotels);
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDto>> GetHotel(int id)
    {
        var hotel = await _hotelsRepository.GetDetails(id);

        if (hotel is null)
            return NotFound();

        var getCity = _mapper.Map<HotelDto>(hotel);

        return Ok(getCity);
    }

    // PUT: api/Hotels/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int id, UpdateHotelDto updatedHotel)
    {
        if (id != updatedHotel.Id)
        {
            return BadRequest();
        }

        //_context.Entry(hotel).State = EntityState.Modified;

        var hotel = await _hotelsRepository.GetAsync(id);

        if (hotel is null)
            return NotFound();

        _mapper.Map(updatedHotel, hotel);

        try
        {
            await _hotelsRepository.UpdateAsync(hotel);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HotelExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Hotels
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotel)
    {
        var hotel = _mapper.Map<Hotel>(createHotel);

        if (hotel is null)
            return Problem("Entity set 'DataContext.Hotels'  is null.");

        await _hotelsRepository.AddAsync(hotel);

        return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var hotel = await _hotelsRepository.GetAsync(id);

        if (hotel is null)
        {
            return NotFound();
        }

        await _hotelsRepository.DeleteAsync(id);

        return NoContent();
    }

    private async Task<bool> HotelExists(int id)
    {
        return await _hotelsRepository.Exists(id);
        //return (_context.Hotels?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
