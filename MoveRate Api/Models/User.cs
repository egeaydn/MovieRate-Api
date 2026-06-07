namespace MoveRate_Api.Models
{
	public class User : BaseEntity
	{

		public string Username { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string PasswordHash { get; set; } = string.Empty;

		public DateTime CreatedAt { get; set; }

		public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
	}
}
