using ElectronicsShop.Application.Auth;
using ElectronicsShop.Core.Enums;
using ElectronicsShop.Application.Users.Dtos;
using ElectronicsShop.Core.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ElectronicsShop.Application.Users;
using ElectronicsShop.Application.Auth.Dtos;

namespace ElectronicsShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        public readonly IAuthAppService _authAppService;
        public readonly IUserAppService _userAppService;
        public AuthController(IAuthAppService authAppService, IUserAppService userAppService)
        {
            _authAppService = authAppService;
            _userAppService = userAppService;
        }

        [HttpPost("Register")]
        public async Task<int> Register(UserDto user)
        {
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
            User loginUser = await _authAppService.ValidateUser(new User
            {
                Username = user.Username
            }, user.Password);

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
            //var loggedInUserId = await _authAppService.GetLoggedInUserId();
            //if(loggedInUserId == null)
            //{
            //    return await Task.FromResult(null as GetLoggedInUserDto);
            //}

            //var loggedInUser = _userAppService.GetUserById(loggedInUserId.Value);

            var loggedInUser = await _authAppService.GetLoggedInUser();

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
