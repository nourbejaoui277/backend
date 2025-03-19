using Backend_Mobile.Data;
using Backend_Mobile.Entities;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace Backend_Mobile.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> createUser(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
            {
                throw new ArgumentException("Failed to add user");
            }
            return user;
        }

        public async Task<UserEntity?> AuthenticateUser(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<UserEntity?> GetUserByEmail(string email)
        {
            
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
