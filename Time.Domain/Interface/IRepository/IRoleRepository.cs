using TimeMark.Models;

namespace Time.Domain.Interface
{
	public interface IRoleRepository
	{
		Task<IEnumerable<Role>> GetAll();
		Task<Role?> GetById(int id);
		Task<Role> Add(Role role);
		Task<Role?> Update(Role role);
		Task<bool> Delete(int id);
	}
}