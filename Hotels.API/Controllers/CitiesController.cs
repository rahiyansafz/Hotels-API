using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.Models.Models;
using Hotels.Models.Dtos.City;
using AutoMapper;
using Hotels.DataAccess.Contracts;
using Microsoft.AspNetCore.Authorization;
using Hotels.Models.Exceptions;
using Hotels.Models.Models.Response;
using Hotels.Models.Models.QueryResponse;

namespace Hotels.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICitiesRepository _citiesRepository;
    private readonly ILogger<CitiesController> _logger;

    public CitiesController(IMapper mapper, ICitiesRepository citiesRepository, ILogger<CitiesController> logger)
    {
        _mapper = mapper;
        _citiesRepository = citiesRepository;
        _logger = logger;
    }

    // GET: api/v1/Cities/GetAll
    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<GetCityDto>>> GetCities()
    {
        var cities = await _citiesRepository.GetAllAsync<GetCityDto>();

        if (cities is null)
            return NotFound();

        return Ok(cities);
    }

    // GET: api/v1/Cities/?StartIndex=0&pagesize=25&PageNumber=1
    [HttpGet]
    public async Task<ActionResult<PagedResult<GetCityDto>>> GetPagedCities([FromQuery] QueryParameters queryParameters)
    {
        var cities = await _citiesRepository.GetAllAsync<GetCityDto>(queryParameters);
        return Ok(cities);
    }

    // GET: api/v1/Cities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CityDto>> GetCity(int id)
    {
        var city = await _citiesRepository.GetDetails(id);

        if (city is null)
            throw new NotFoundException(nameof(GetCity), id);

        return Ok(city);
    }

    // PUT: api/v1/Cities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutCity(int id, UpdateCityDto updatedCity)
    {
        if (id != updatedCity.Id)
            return BadRequest("Invalid Record Id");

        try
        {
            await _citiesRepository.UpdateAsync(id, updatedCity);
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

    // POST: api/v1/Cities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<CityDto>> PostCity(CreateCityDto createCity)
    {
        var city = await _citiesRepository.AddAsync<CreateCityDto, GetCityDto>(createCity);

        return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
    }

    // DELETE: api/v1/Cities/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        await _citiesRepository.DeleteAsync(id);

        return NoContent();
    }

    private async Task<bool> CityExists(int id)
    {
        return await _citiesRepository.Exists(id);
    }
}
