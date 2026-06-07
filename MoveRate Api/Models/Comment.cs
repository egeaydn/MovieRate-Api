namespace MoveRate_Api.Models
{
	public class Comment : BaseEntity
	{
		public string Content { get; set; } = string.Empty;

		public DateTime CreatedAt { get; set; }

		public int UserId { get; set; }

		public User User { get; set; } = null!;

		public int MovieId { get; set; }

		public Movie Movie { get; set; } = null!;
	}
}
