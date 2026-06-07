namespace MoveRate_Api.Models
{
	public class Rating : BaseEntity
	{

		public int Score { get; set; }

		public int UserId { get; set; }

		public User User { get; set; } = null!;

		public int MovieId { get; set; }

		public Movie Movie { get; set; } = null!;
	}
}
