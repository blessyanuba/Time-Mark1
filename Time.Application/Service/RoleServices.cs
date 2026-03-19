using System.Collections.Generic;
using System.Threading.Tasks;
using Time.Domain.Interface;
using TimeMark.Models;

namespace Time.Application.Service
{
	public class RoleService : IRoleService
	{
		private readonly IRoleRepository _repo;

		public RoleService(IRoleRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<Role>> GetAllRoles()
		{
			return await _repo.GetAll();
		}

		public async Task<Role?> GetRoleById(int id)
		{
			return await _repo.GetById(id);
		}

		public async Task<Role> CreateRole(Role role)
		{
			return await _repo.Add(role);
		}

		public async Task<Role?> UpdateRole(Role role)
		{
			return await _repo.Update(role);
		}

		public async Task<bool> DeleteRole(int id)
		{
			return await _repo.Delete(id);
		}
	}
}