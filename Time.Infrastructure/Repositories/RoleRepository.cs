using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Time.Domain.Interface;
using TimeMark.Models;

namespace Time.Infrastructure.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private readonly EasyDbContext _context;

		public RoleRepository(EasyDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Role>> GetAll()
		{
			return await _context.Roles.ToListAsync();
		}

		public async Task<Role?> GetById(int id)
		{
			return await _context.Roles.FindAsync(id);
		}

		public async Task<Role> Add(Role role)
		{
			_context.Roles.Add(role);
			await _context.SaveChangesAsync();
			return role;
		}

		public async Task<Role?> Update(Role role)
		{
			var existingRole = await _context.Roles.FindAsync(role.RoleId);

			if (existingRole == null)
				return null;

			existingRole.RoleName = role.RoleName;
			existingRole.Description = role.Description;

			await _context.SaveChangesAsync();
			return existingRole;
		}

		public async Task<bool> Delete(int id)
		{
			var role = await _context.Roles.FindAsync(id);

			if (role == null)
				return false;

			_context.Roles.Remove(role);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}