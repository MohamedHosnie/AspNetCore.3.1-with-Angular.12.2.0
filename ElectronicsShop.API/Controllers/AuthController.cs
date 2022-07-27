using ElectronicsShop.Application.Auth;
using ElectronicsShop.Shared.Enums;
using ElectronicsShop.Application.Users.Dtos;
using ElectronicsShop.Core.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ElectronicsShop.Application.Users;
using ElectronicsShop.Application.Auth.Dtos;
using System;

namespace ElectronicsShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        public readonly IAuthAppService _authAppService;
        public readonly IUserAppService _userAppService;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public AuthController(IAuthAppService authAppService, IUserAppService userAppService, IHttpContextAccessor httpContextAccessor)
        {
            _authAppService = authAppService;
            _userAppService = userAppService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Register")]
        public async Task<int> Register(UserDto user)
        {
            var unique = _userAppService.UsernameIsUnique(user.Username);

            if(!unique)
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = 400;
                return -1; // Username unavailable
            }

            var createdUserId = await _authAppService.CreateUser(new User
            {
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                FullAddress = user.FullAddress,
                PhoneNumber = user.PhoneNumber,
            }, user.Password);

            return createdUserId;
        }

        [HttpPost("Login")]
        public async Task<string> Login(LoginDto user)
        {
            User loginUser = await _authAppService.ValidateUser(user.Username, user.Password);

            return await _authAppService.CreateJwtToken(loginUser);
        }

        [HttpGet("IsAuthenticated"), Authorize]
        public async Task<bool> IsAuthenticated()
        {
            return await Task.FromResult(true);
        }

        [HttpGet("GetLoggedInUser"), Authorize]
        public async Task<GetLoggedInUserDto> GetLoggedInUser()
        {
            var loggedInUser = await _authAppService.GetLoggedInUser();
            if (loggedInUser == null)
            {
                return await Task.FromResult(null as GetLoggedInUserDto);
            }

            return new GetLoggedInUserDto
            {
                Id = loggedInUser.Id,
                Username = loggedInUser.Username,
                FullName = loggedInUser.FullName,
                FullAddress = loggedInUser.FullAddress,
                BirthDate = loggedInUser.BirthDate,
                Email = loggedInUser.Email,
                PhoneNumber = loggedInUser.PhoneNumber,
                Role = loggedInUser.Role.Name()
            };
        }

    }
}
