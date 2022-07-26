
//https://jasonwatmore.com/post/2020/07/16/aspnet-core-3-hash-and-verify-passwords-with-bcrypt
using BC = BCrypt.Net.BCrypt;
using ElectronicsShop.Core.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using ElectronicsShop.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace ElectronicsShop.Application.Auth
{
    public class AuthAppService : ElectronicsShopAppServiceBase, IAuthAppService
    {
        static User staticUser = new User();
        public readonly IConfiguration _configuration;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public AuthAppService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CreateUser(User user, string password)
        {
            var passwordHash = BC.HashPassword(password);

            staticUser = user;
            staticUser.Id = 10;
            staticUser.PasswordHash = passwordHash;
            staticUser.Role = Role.Admin;

            return await Task.FromResult(staticUser.Id);
        }

        public Task<User> ValidateUser(User user, string password)
        {
            if (user.Username == staticUser.Username
            && BC.Verify(password, staticUser.PasswordHash))
            {
                return Task.FromResult(staticUser);
            }

            throw new Exception("Username or Password Incorrect!");
        }

        public Task<string> CreateJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name()),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value));
            var expiryDays = Int32.Parse(_configuration.GetSection("AppSettings:JwtExpiryDays").Value);

            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha384Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(expiryDays),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(jwt);
        }

        public Task<int?> GetLoggedInUserId()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null) return Task.FromResult(null as int?);

            var userIdValue = user.FindFirstValue("Id");
            if (userIdValue == null) return Task.FromResult(null as int?);

            if (!Int32.TryParse(userIdValue, out int userId)) return Task.FromResult(null as int?);

            return Task.FromResult(userId as int?);
        }

        public Task<User> GetLoggedInUser()
        {
            return Task.FromResult(staticUser);
        }
    }
}
