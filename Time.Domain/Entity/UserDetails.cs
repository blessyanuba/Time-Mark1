using TimeMark.Models;

namespace Time.Domain.Entity
{
	public class UserDetail
	{
		public int UserDetailID { get; set; }
		public int UserID { get; set; }

		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;

		public User User { get; set; }
	}
}