namespace Time.Application.DTOs
{
	public class UserResponseDto
	{
		public int UserID { get; set; }
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public int RoleID { get; set; }
		public string? RoleName { get; set; }
	}
}