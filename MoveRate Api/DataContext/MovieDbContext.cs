using Microsoft.EntityFrameworkCore;
using MoveRate_Api.Models;

namespace MoveRate_Api.DataContext
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<User> Users => Set<User>();
		public DbSet<Movie> Movies => Set<Movie>();
		public DbSet<Genre> Genres => Set<Genre>();
		public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
		public DbSet<Rating> Ratings => Set<Rating>();
		public DbSet<Comment> Comments => Set<Comment>();
		public DbSet<WatchList> WatchLists => Set<WatchList>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MovieGenre>()
				.HasKey(x => new { x.MovieId, x.GenreId });

			base.OnModelCreating(modelBuilder);
		}
	}
}