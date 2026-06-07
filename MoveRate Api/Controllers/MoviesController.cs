using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveRate_Api.DataContext;
using MoveRate_Api.Models;

namespace MoveRate_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public MoviesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/Movies
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
		{
			return await _context.Movies.ToListAsync();
		}

		// GET: api/Movies/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Movie>> GetMovie(int id)
		{
			var movie = await _context.Movies.FindAsync(id);

			if (movie == null)
			{
				return NotFound("Film bulunamadı.");
			}

			return movie;
		}

		// POST: api/Movies
		[HttpPost]
		public async Task<ActionResult<Movie>> PostMovie(Movie movie)
		{
			_context.Movies.Add(movie);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
		}

		// PUT: api/Movies/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMovie(int id, Movie movie)
		{
			if (id != movie.Id)
			{
				return BadRequest("ID uyuşmazlığı.");
			}

			_context.Entry(movie).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MovieExists(id))
				{
					return NotFound("Güncellenmek istenen film bulunamadı.");
				}
				throw;
			}

			return NoContent();
		}

		// DELETE: api/Movies/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMovie(int id)
		{
			var movie = await _context.Movies.FindAsync(id);
			if (movie == null)
			{
				return NotFound("Silinecek film bulunamadı.");
			}

			_context.Movies.Remove(movie);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MovieExists(int id)
		{
			return _context.Movies.Any(e => e.Id == id);
		}
	}
}