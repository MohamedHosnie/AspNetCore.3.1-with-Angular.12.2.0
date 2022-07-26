﻿
//https://jasonwatmore.com/post/2020/07/16/aspnet-core-3-hash-and-verify-passwords-with-bcrypt
using BC = BCrypt.Net.BCrypt;
using ElectronicsShop.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using ElectronicsShop.Domain.Products;
using ElectronicsShop.Shared.Enums;
using Microsoft.AspNetCore.Http;
using ElectronicsShop.Domain.Repositories;

namespace ElectronicsShop.Application.Auth
{
    public class AuthAppService : ElectronicsShopAppServiceBase, IAuthAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<User, int> _userRepository;

        public AuthAppService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IRepository<User, int> userRepository, IProductDomainService productDomainService)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            
        }

        public async Task<int> CreateUser(User user, string password)
        {
            var passwordHash = BC.HashPassword(password);

            user.PasswordHash = passwordHash;
            user.Role = Role.Customer;
            
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
            
            return user.Id;
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            var savedUser = await _userRepository.GetSingleAsync(filter: user => user.Username == username);
            if (savedUser != null
            && BC.Verify(password, savedUser.PasswordHash))
            {
                return await Task.FromResult(savedUser);
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

            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha384Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(expiryDays),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(jwt);
        }

        public async Task<User> GetLoggedInUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null) return await Task.FromResult(null as User);

            var userIdValue = user.FindFirstValue("Id");
            if (userIdValue == null) return await Task.FromResult(null as User);

            if (!Int32.TryParse(userIdValue, out int userId)) return await Task.FromResult(null as User);

            return await _userRepository.GetAsync(userId);
        }
    }
}
