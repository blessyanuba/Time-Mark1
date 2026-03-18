using System;
using System.Collections.Generic;

namespace TimeMark.Models;

public partial class User
{
	public int Id { get; set; }

	public string UserName { get; set; } = null!;

	public string PasswordHash { get; set; } = null!;

	public string Email { get; set; } = null!;

	public int RoleId { get; set; }

	public DateTime CreatedAt { get; set; }

	public virtual ICollection<Attendance> AttendanceRecordedByNavigations { get; set; } = new List<Attendance>();

	public virtual ICollection<Attendance> AttendanceUsers { get; set; } = new List<Attendance>();

	public virtual Role Role { get; set; } = null!;

	public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
