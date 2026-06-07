using MoveRate_Api.Models;

public class Movie : BaseEntity
{

	public string Title { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public int ReleaseYear { get; set; }

	public string PosterUrl { get; set; } = string.Empty;

	public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

	public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}