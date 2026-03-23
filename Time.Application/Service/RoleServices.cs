using TimeMark.Interfaces;
using TimeMark.Models;

namespace TimeMark.Services
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

		public async Task<Role?> UpdateRole(int id, Role role)
		{
			var existing = await _repo.GetById(id);
			if (existing == null)
				return null;

			existing.RoleName = role.RoleName;
			return await _repo.Update(existing);
		}

		public async Task<bool> DeleteRole(int id)
		{
			return await _repo.Delete(id);
		}

        Task<User> IRoleService.DeleteRole(int id)
        {
            throw new NotImplementedException();
        }
    }
}