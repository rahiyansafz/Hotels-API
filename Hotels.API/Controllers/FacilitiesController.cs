using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Hotels.DataAccess.Contracts;
using AutoMapper;
using Hotels.Models.Dtos.Facility;

namespace Hotels.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class FacilitiesController : ControllerBase
{
    private readonly IFacilitiesRepository _facilitiesRepository;
    private readonly IMapper _mapper;

    public FacilitiesController(IFacilitiesRepository facilitiesRepository, IMapper mapper)
    {
        _facilitiesRepository = facilitiesRepository;
        _mapper = mapper;
    }

    // GET: api/v1/Facilities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FacilityDto>>> GetFacilities()
    {
        var facilities = await _facilitiesRepository.GetAllAsync<FacilityDto>();
        return Ok(facilities);
    }

    // GET: api/v1/Facilities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FacilityDto>> GetFacility(int id)
    {
        var facility = await _facilitiesRepository.GetAsync<FacilityDto>(id);
        return Ok(facility);
    }

    // PUT: api/v1/Facilities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutFacility(int id, FacilityDto facility)
    {
        if (id != facility.Id)
            return BadRequest("Invalid Record Id");

        try
        {
            await _facilitiesRepository.UpdateAsync(id, facility);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await FacilityExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/v1/Facilities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<FacilityDto>> PostFacility(CreateFacilityDto facilityDto)
    {
        var facility = await _facilitiesRepository.AddAsync<CreateFacilityDto, FacilityDto>(facilityDto);
        return CreatedAtAction(nameof(GetFacility), new { id = facility.Id }, facility);
    }

    // DELETE: api/v1/Facilities/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteFacility(int id)
    {
        await _facilitiesRepository.DeleteAsync(id);
        return NoContent();
    }

    private async Task<bool> FacilityExists(int id)
    {
        return await _facilitiesRepository.Exists(id);
    }
}
