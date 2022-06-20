using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using Hotels.Models.Dtos.City;
using AutoMapper;

namespace Hotels.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CitiesController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Cities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCityDto>>> GetCities()
    {
        if (_context.Cities is null)
            return NotFound();

        var cities = await _context.Cities.ToListAsync();
        var getCities = _mapper.Map<List<GetCityDto>>(cities);

        return Ok(getCities);
    }

    // GET: api/Cities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CityDto>> GetCity(int id)
    {
        if (_context.Cities is null)
            return NotFound();

        var city = await _context.Cities.Include(q => q.Hotels)
            .FirstOrDefaultAsync(q => q.Id == id);

        if (city is null)
            return NotFound();

        var getCity = _mapper.Map<CityDto>(city);

        return Ok(getCity);
    }

    // PUT: api/Cities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCity(int id, UpdateCityDto updatedCity)
    {
        if (id != updatedCity.Id)
            return BadRequest();

        //_context.Entry(city).State = EntityState.Modified;

        var city = await _context.Cities.FindAsync(id);

        if (city is null)
            return NotFound();

        _mapper.Map(updatedCity, city);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CityExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/Cities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<City>> PostCity(CreateCityDto createCity)
    {
        if (_context.Cities is null)
            return Problem("Entity set 'DataContext.Cities'  is null.");

        var city = _mapper.Map<City>(createCity);

        _context.Cities.Add(city);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCity", new { id = city.Id }, city);
    }

    // DELETE: api/Cities/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        if (_context.Cities is null)
            return NotFound();

        var city = await _context.Cities.FindAsync(id);
        if (city is null)
            return NotFound();

        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CityExists(int id)
    {
        return (_context.Cities?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
