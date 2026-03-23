using Time.Domain.Entity;
using TimeMark.Models;

namespace Time.Application.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<User>> GetAll();
		Task<User?> GetById(int id);
		Task<User> Add(User user);
		Task<User?> Update(User user);
		Task<bool> Delete(int id);
	}
}