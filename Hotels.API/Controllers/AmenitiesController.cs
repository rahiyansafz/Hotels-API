using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Hotels.DataAccess.Contracts;
using AutoMapper;
using Hotels.Models.Dtos.Amenity;

namespace Hotels.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AmenitiesController : ControllerBase
{
    private readonly IAmenitiesRepository _amenitiesRepository;
    private readonly IMapper _mapper;

    public AmenitiesController(IAmenitiesRepository amenitiesRepository, IMapper mapper)
    {
        _amenitiesRepository = amenitiesRepository;
        _mapper = mapper;
    }

    // GET: api/v1/Amenities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AmenityDto>>> GetAmenities()
    {
        var amenities = await _amenitiesRepository.GetAllAsync<AmenityDto>();
        return Ok(amenities);
    }

    // GET: api/v1/Amenities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AmenityDto>> GetAmenity(int id)
    {
        var amenity = await _amenitiesRepository.GetAsync<AmenityDto>(id);
        return Ok(amenity);
    }

    // PUT: api/v1/Amenities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutAmenity(int id, AmenityDto amenity)
    {
        if (id != amenity.Id)
        {
            return BadRequest("Invalid Record Id");
        }

        try
        {
            await _amenitiesRepository.UpdateAsync(id, amenity);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await AmenityExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/v1/Amenities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<AmenityDto>> PostAmenity(CreateAmenityDto amenityDto)
    {
        var amenity = await _amenitiesRepository.AddAsync<CreateAmenityDto, AmenityDto>(amenityDto);
        return CreatedAtAction(nameof(GetAmenity), new { id = amenity.Id }, amenity);
    }

    // DELETE: api/v1/Amenities/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteAmenity(int id)
    {
        await _amenitiesRepository.DeleteAsync(id);
        return NoContent();
    }

    private async Task<bool> AmenityExists(int id)
    {
        return await _amenitiesRepository.Exists(id);
    }
}
