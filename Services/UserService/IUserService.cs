using Backend.Models;
using Backend_Mobile.Entities;

namespace Backend_Mobile.Services.UserService
{
    public interface IUserService
    {
        Task<UserEntity> createUser(UserEntity user);
        Task<LoginResponseDTO?> AuthenticateUser(string email, string password);
        Task<UserEntity?> GetUserProfile(string email);
    }
}