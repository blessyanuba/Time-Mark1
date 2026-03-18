using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace TimeMark.Models;

public partial class EasyDbContext : DbContext
{
	public EasyDbContext()
	{
	}

	public EasyDbContext(DbContextOptions<EasyDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Attendance> Attendances { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	public virtual DbSet<User> Users { get; set; }

	public virtual DbSet<UserDetail> UserDetails { get; set; }




	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Attendance>(entity =>
		{
			entity.HasIndex(e => e.RecordedBy, "IX_Attendances_RecordedBy");

			entity.HasIndex(e => e.UserId, "IX_Attendances_UserID");

			entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
			entity.Property(e => e.UserId).HasColumnName("UserID");

			entity.HasOne(d => d.RecordedByNavigation).WithMany(p => p.AttendanceRecordedByNavigations)
				.HasForeignKey(d => d.RecordedBy)
				.OnDelete(DeleteBehavior.ClientSetNull);

			entity.HasOne(d => d.User).WithMany(p => p.AttendanceUsers)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull);
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.Property(e => e.RoleId).HasColumnName("RoleID");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.HasIndex(e => e.RoleId, "IX_Users_RoleID");

			entity.Property(e => e.RoleId).HasColumnName("RoleID");

			entity.HasOne(d => d.Role).WithMany(p => p.Users).HasForeignKey(d => d.RoleId);
		});

		modelBuilder.Entity<UserDetail>(entity =>
		{
			entity.HasIndex(e => e.UserId, "IX_UserDetails_UserID");

			entity.Property(e => e.Dob).HasColumnName("DOB");
			entity.Property(e => e.UserId).HasColumnName("UserID");
			entity.Property(e => e.Year).HasColumnName("year");

			entity.HasOne(d => d.User).WithMany(p => p.UserDetails).HasForeignKey(d => d.UserId);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
