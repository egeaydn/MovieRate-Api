using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveRate_Api.DataContext;
using MoveRate_Api.Models;

namespace MoveRate_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieGenresController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public MovieGenresController(ApplicationDbContext context)
		{
			_context = context;
		}

		// POST: api/MovieGenres (Filme Tür Ekleme)
		[HttpPost]
		public async Task<ActionResult<MovieGenre>> AddGenreToMovie(MovieGenre movieGenre)
		{
			_context.MovieGenres.Add(movieGenre);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (MovieGenreExists(movieGenre.MovieId, movieGenre.GenreId))
				{
					return Conflict("Bu film zaten bu türe sahip.");
				}
				throw;
			}

			return Ok(movieGenre);
		}

		// DELETE: api/MovieGenres/5/2 (Filmden Türü Kaldırma)
		[HttpDelete("{movieId}/{genreId}")]
		public async Task<IActionResult> RemoveGenreFromMovie(int movieId, int genreId)
		{
			var movieGenre = await _context.MovieGenres.FindAsync(movieId, genreId);
			if (movieGenre == null)
			{
				return NotFound("Kayıt bulunamadı.");
			}

			_context.MovieGenres.Remove(movieGenre);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MovieGenreExists(int movieId, int genreId)
		{
			return _context.MovieGenres.Any(e => e.MovieId == movieId && e.GenreId == genreId);
		}
	}
}