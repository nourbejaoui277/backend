using Backend_Mobile.Entities;

namespace Backend_Mobile.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<UserEntity> createUser(UserEntity user);
        Task<UserEntity?> AuthenticateUser(string email, string password);
        Task<UserEntity?> GetUserByEmail(string email); 
    }
}
