using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hotels.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class FeedbacksController : ControllerBase
{
    private readonly DataContext _context;

    public FeedbacksController(DataContext context)
    {
        _context = context;
    }

    // GET: api/v1/Feedbacks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
    {
      if (_context.Feedbacks == null)
      {
          return NotFound();
      }
        return await _context.Feedbacks.ToListAsync();
    }

    // GET: api/v1/Feedbacks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Feedback>> GetFeedback(int id)
    {
      if (_context.Feedbacks == null)
      {
          return NotFound();
      }
        var feedback = await _context.Feedbacks.FindAsync(id);

        if (feedback == null)
        {
            return NotFound();
        }

        return feedback;
    }

    // PUT: api/v1/Feedbacks/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
    {
        if (id != feedback.Id)
        {
            return BadRequest();
        }

        _context.Entry(feedback).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FeedbackExists(id))
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

    // POST: api/v1/Feedbacks
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
    {
      if (_context.Feedbacks == null)
      {
          return Problem("Entity set 'DataContext.Feedbacks'  is null.");
      }
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFeedback", new { id = feedback.Id }, feedback);
    }

    // DELETE: api/v1/Feedbacks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        if (_context.Feedbacks == null)
        {
            return NotFound();
        }
        var feedback = await _context.Feedbacks.FindAsync(id);
        if (feedback == null)
        {
            return NotFound();
        }

        _context.Feedbacks.Remove(feedback);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FeedbackExists(int id)
    {
        return (_context.Feedbacks?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
