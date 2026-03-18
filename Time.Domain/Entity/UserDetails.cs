using System;
using System.Collections.Generic;
//using Time.Domain.Entity;

namespace TimeMark.Models;

public partial class UserDetail
{
	public int Id { get; set; }

	public int UserId { get; set; }

	public string FullName { get; set; } = null!;

	public DateTime Dob { get; set; }

	public string Gender { get; set; } = null!;

	public string PhoneNumber { get; set; } = null!;

	public string Address { get; set; } = null!;

	public string Department { get; set; } = null!;

	public int Year { get; set; }

	public virtual User User { get; set; } = null!;
}
