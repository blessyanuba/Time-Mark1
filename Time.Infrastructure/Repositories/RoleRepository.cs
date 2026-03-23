using Microsoft.EntityFrameworkCore;
using TimeMark.Data;
using TimeMark.Data;
using TimeMark.Interfaces;
using TimeMark.Models;

namespace TimeMark.Repositories
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
			return await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
		}

		public async Task<Role> Add(Role role)
		{
			_context.Roles.Add(role);
			await _context.SaveChangesAsync();
			return role;
		}

		public async Task<Role> Update(Role role)
		{
			_context.Roles.Update(role);
			await _context.SaveChangesAsync();
			return role;
		}

		public async Task<bool> Delete(int id)
		{
			var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
			if (role == null)
				return false;

			_context.Roles.Remove(role);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}