namespace Time.Application.DTOs
{
	public class UserUpdateDto
	{
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public int RoleID { get; set; }
	}
}