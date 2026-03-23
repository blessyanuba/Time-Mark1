using Time.Application.Interfaces;
using Time.Domain.Interface.IRepository;
using TimeMark.Interfaces;
using TimeMark.Models;

namespace TimeMark.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repo;

		public UserService(IUserRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<User>> GetAllUsers()
		{
			return await _repo.GetAllData();
		}

		public async Task<User?> GetUserById(int id)
		{
			return await _repo.GetById(id);
		}

		public async Task<User> CreateUser(User user)
		{
			var result= await _repo.AddData(user);
			return result;
		}

		public async Task<User?> UpdateUser(int id, User user)
		{
			var existingUser = await _repo.GetById(id);
			if (existingUser == null)
				return null;

			existingUser.UserName = user.UserName;
			existingUser.Email = user.Email;
			existingUser.Password = user.Password;
			existingUser.RoleId = user.RoleId;

			var result= await _repo.UpdateData(existingUser);
			return result;
		}

		public async Task<User> DeleteUser(int id)
		{
			var result= await _repo.DeleteData(id);
			return result;
		}

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}