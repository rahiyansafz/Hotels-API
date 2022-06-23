using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.Models.Models;
using Hotels.Models.Dtos.City;
using AutoMapper;
using Hotels.DataAccess.Contracts;
using Microsoft.AspNetCore.Authorization;
using Hotels.API.Exceptions;

namespace Hotels.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICitiesRepository _citiesRepository;

    public CitiesController(IMapper mapper, ICitiesRepository citiesRepository)
    {
        _mapper = mapper;
        _citiesRepository = citiesRepository;
    }

    // GET: api/Cities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCityDto>>> GetCities()
    {
        var cities = await _citiesRepository.GetAllAsync();

        if (cities is null)
            return NotFound();

        var getCities = _mapper.Map<List<GetCityDto>>(cities);

        return Ok(getCities);
    }

    // GET: api/Cities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CityDto>> GetCity(int id)
    {
        var city = await _citiesRepository.GetDetails(id);

        if (city is null)
            throw new NotFoundException(nameof(GetCity), id);

        var getCity = _mapper.Map<CityDto>(city);

        return Ok(getCity);
    }

    // PUT: api/Cities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutCity(int id, UpdateCityDto updatedCity)
    {
        if (id != updatedCity.Id)
            return BadRequest("Invalid Record Id");

        //_context.Entry(city).State = EntityState.Modified;

        var city = await _citiesRepository.GetAsync(id);

        if (city is null)
            throw new NotFoundException(nameof(GetCities), id);

        _mapper.Map(updatedCity, city);

        try
        {
            await _citiesRepository.UpdateAsync(city);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CityExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/Cities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<City>> PostCity(CreateCityDto createCity)
    {
        var city = _mapper.Map<City>(createCity);

        if (city is null)
            return Problem("Entity set 'DataContext.Cities'  is null.");

        await _citiesRepository.AddAsync(city);

        return CreatedAtAction("GetCity", new { id = city.Id }, city);
    }

    // DELETE: api/Cities/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        var city = await _citiesRepository.GetAsync(id);

        if (city is null)
            throw new NotFoundException(nameof(GetCities), id);

        await _citiesRepository.DeleteAsync(id);

        return NoContent();
    }

    private async Task<bool> CityExists(int id)
    {
        return await _citiesRepository.Exists(id);
        //return (_context.Cities?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
