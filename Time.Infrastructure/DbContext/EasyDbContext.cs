using Microsoft.EntityFrameworkCore;
using Time.Domain.Entity;
using TimeMark.Models;

namespace TimeMark.Data
{
	public class EasyDbContext : DbContext
	{
		public EasyDbContext(DbContextOptions<EasyDbContext> options)
			: base(options)
		{
		}

		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserDetail> UserDetails { get; set; }
	}
}