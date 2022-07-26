
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

namespace ElectronicsShop.Application.Auth
{
    public class AuthAppService : IAuthAppService
    {
        static User staticUser = new User();
        public readonly IConfiguration _configuration;

        public AuthAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> CreateUser(User user, string password)
        {
            var passwordHash = BC.HashPassword(password);

            staticUser.Username = user.Username;
            staticUser.PasswordHash = passwordHash;

            return await Task.FromResult(user);
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
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, Roles.Admin),
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

    }
}
