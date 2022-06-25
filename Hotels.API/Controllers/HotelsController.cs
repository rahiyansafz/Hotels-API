using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.Models.Dtos.Hotel;
using Microsoft.AspNetCore.Authorization;
using Hotels.Models.Models.Response;
using Hotels.Models.Models.QueryResponse;
using Hotels.Models.Exceptions;
using Microsoft.AspNetCore.OData.Query;

namespace Hotels.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
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

    // GET: api/v1/Hotels/GetAll
    [HttpGet("GetAll")]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<GetHotelDto>>> GetHotels()
    {
        var hotels = await _hotelsRepository.GetAllAsync<GetHotelDto>();
        return Ok(hotels);
    }

    // GET: api/Hotels/?StartIndex=0&pagesize=25&PageNumber=1
    [HttpGet]
    public async Task<ActionResult<PagedResult<GetHotelDto>>> GetPagedHotels([FromQuery] QueryParameters queryParameters)
    {
        var hotels = await _hotelsRepository.GetAllAsync<GetHotelDto>(queryParameters);
        return Ok(hotels);
    }

    // GET: api/v1/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDto>> GetHotel(int id)
    {
        var hotel = await _hotelsRepository.GetDetails(id);
        return Ok(hotel);
    }

    // PUT: api/v1/Hotels/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutHotel(int id, UpdateHotelDto updatedHotel)
    {
        if (id != updatedHotel.Id)
            return BadRequest("Invalid Record Id");

        try
        {
            await _hotelsRepository.UpdateAsync(id, updatedHotel);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HotelExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/v1/Hotels
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<HotelDto>> PostHotel(CreateHotelDto createHotel)
    {
        var hotel = await _hotelsRepository.AddAsync<CreateHotelDto, GetHotelDto>(createHotel);
        return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }

    // DELETE: api/v1/Hotels/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        await _hotelsRepository.DeleteAsync(id);
        return NoContent();
    }

    private async Task<bool> HotelExists(int id)
    {
        return await _hotelsRepository.Exists(id);
    }
}
