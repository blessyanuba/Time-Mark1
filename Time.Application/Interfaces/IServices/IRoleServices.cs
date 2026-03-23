using TimeMark.Models;

namespace TimeMark.Interfaces
{
	public interface IRoleService
	{
		Task<IEnumerable<Role>> GetAllRoles();
		Task<Role?> GetRoleById(int id);
		Task<Role> CreateRole(Role role);
		Task<Role?> UpdateRole(int id, Role role);
		Task<User> DeleteRole(int id);
	}
}