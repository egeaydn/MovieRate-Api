using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveRate_Api.DataContext;

namespace MoveRate_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenresController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		public GenresController(ApplicationDbContext context) => _context = context;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Genre>>> GetGenres() => await _context.Genres.ToListAsync();

		[HttpGet("{id}")]
		public async Task<ActionResult<Genre>> GetGenre(int id)
		{
			var genre = await _context.Genres.FindAsync(id);
			return genre == null ? NotFound() : genre;
		}

		[HttpPost]
		public async Task<ActionResult<Genre>> PostGenre(Genre genre)
		{
			_context.Genres.Add(genre);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutGenre(int id, Genre genre)
		{
			if (id != genre.Id) return BadRequest();
			_context.Entry(genre).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGenre(int id)
		{
			var genre = await _context.Genres.FindAsync(id);
			if (genre == null) return NotFound();
			_context.Genres.Remove(genre);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}
