using System;
using TimeMark.Models;

namespace Time.Domain.Entity
{
	public class Attendance
	{
		public int AttendanceID { get; set; }
		public int UserID { get; set; }
		public DateTime Date { get; set; }
		public string Status { get; set; } = string.Empty;
		public string Course { get; set; } = string.Empty;
		public int RecordedBy { get; set; }

		public User? User { get; set; }
		public User? RecordedUser { get; set; }
	}
}