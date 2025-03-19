using Backend_Mobile.Entities;
using Backend_Mobile.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Backend.Models;

namespace Backend_Mobile.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<UserEntity> createUser(UserEntity user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return await _userRepository.createUser(user);
        }

        public async Task<LoginResponseDTO?> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.AuthenticateUser(email, password);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }


            // Generate the JWT token string
            var token = await GenerateJwtTokenAsync(user);
            return new LoginResponseDTO
            {
                token = token,
                Expiration = DateTime.UtcNow.AddHours(2),
            };
        }

        public async Task<UserEntity?> GetUserProfile(string email)
        {
            
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<string> GenerateJwtTokenAsync(UserEntity user)
        {
            var claims = new[]
            {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}