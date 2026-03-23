using Time.Domain.Entity;
using TimeMark.Models;

namespace Time.Domain.Interface.IRepository
{
	public interface IUserRepository
	{
		Task<List<User>> GetAllData();
		Task<User> GetById(int id);
		Task<User>AddData(User user);
		Task<User>UpdateData(User user);
		Task<User>DeleteData(int id);

	}
}