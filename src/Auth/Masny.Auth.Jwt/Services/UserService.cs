using Masny.Auth.Jwt.Contracts.Requests;
using Masny.Auth.Jwt.Contracts.Responses;
using Masny.Auth.Jwt.Helpers;
using Masny.Auth.Jwt.Interfaces;
using Masny.Auth.Jwt.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Masny.Auth.Jwt.Services
{
    public class UserService : IUserService
    {
        private readonly AppSetting _appSetting;
        private readonly IUserStoreManager _userStoreManager;

        public UserService(
            IOptions<AppSetting> appSettings,
            IUserStoreManager userStoreManager)
        {
            _appSetting = appSettings.Value;
            _userStoreManager = userStoreManager ?? throw new ArgumentNullException(nameof(userStoreManager));
        }

        public async Task<AuthenticationResult> CreateAsync(UserSignUpRequest model)
        {
            var lastUserId = (await _userStoreManager.GetAllAsync())
                .LastOrDefault().Id;

            await _userStoreManager.AddAsync(new User
            {
                Id = ++lastUserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Username = Guid.NewGuid().ToString(),
                Password = model.Password,
            });

            return new AuthenticationResult
            {
                Result = true,
                Message = "User created successfully",
            };
        }

        public async Task<AuthenticationResult> AuthenticateAsync(UserSignInRequest model)
        {
            var user = (await _userStoreManager.GetAllAsync())
                .SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            return user is null
                ? new AuthenticationResult
                {
                    Message = "Username or password is incorrect",
                }
                : new AuthenticationResult
                {
                    Result = true,
                    Message = "User is successfully authenticated",
                    Data = new AuthenticateResponse(user, GenerateJwtToken(user))
                };
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userStoreManager.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return (await _userStoreManager.GetAllAsync())
                .FirstOrDefault(u => u.Id == id);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);

            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
            };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
