using Microsoft.EntityFrameworkCore;
using Time.Domain.Entity;
using Time.Domain.Interface.IRepository;
using TimeMark.Data;
using TimeMark.Models;

namespace Time.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly EasyDbContext context;

		public UserRepository(EasyDbContext context)
		{
			context = context;
		}

        public async Task<User> AddData(User user)
        {
            var data=await context.AddAsync(user);
			context.SaveChangesAsync();
            return user;
            
        }

        public async Task<User> DeleteData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllData()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateData(User user)
        {
            throw new NotImplementedException();
        }
    }
}