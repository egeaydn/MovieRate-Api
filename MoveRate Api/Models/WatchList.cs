namespace MoveRate_Api.Models
{
	public class WatchList : BaseEntity
	{
		public int UserId { get; set; }

		public User User { get; set; } = null!;

		public int MovieId { get; set; }

		public Movie Movie { get; set; } = null!;

		public string Status { get; set; } = string.Empty;
	}
}
