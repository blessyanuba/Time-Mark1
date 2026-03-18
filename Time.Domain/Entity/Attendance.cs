using System;
using System.Collections.Generic;

namespace TimeMark.Models;

public partial class Attendance
{
	public int AttendanceId { get; set; }

	public int UserId { get; set; }

	public DateTime Date { get; set; }

	public string Status { get; set; } = null!;

	public string Course { get; set; } = null!;

	public int RecordedBy { get; set; }

	public virtual User RecordedByNavigation { get; set; } = null!;

	public virtual User User { get; set; } = null!;
}
