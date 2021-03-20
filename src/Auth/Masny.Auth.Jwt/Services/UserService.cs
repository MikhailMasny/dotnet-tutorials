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

        public AuthenticationResult Create(UserSignUpRequest model)
        {
            var lastUserId =
                _userStoreManager
                .GetAll()
                .LastOrDefault().Id;

            _userStoreManager.Add(new User
            {
                Id = ++lastUserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = Guid.NewGuid().ToString(),
                Password = model.Password,
            });

            return new AuthenticationResult
            {
                Result = true,
                Message = "User created successfully",
            };
        }

        public AuthenticationResult Authenticate(UserSignInRequest model)
        {
            var user =
                _userStoreManager
                .GetAll()
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

        public IEnumerable<User> GetAll()
        {
            return _userStoreManager.GetAll();
        }

        public User GetById(int id)
        {
            return _userStoreManager
                .GetAll()
                .FirstOrDefault(u => u.Id == id);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
