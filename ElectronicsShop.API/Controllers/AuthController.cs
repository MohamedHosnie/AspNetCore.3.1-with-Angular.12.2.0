using ElectronicsShop.Application.Auth;
using ElectronicsShop.Application.Auth.Dtos;
using ElectronicsShop.Core.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElectronicsShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        public readonly IAuthAppService _authAppService;
        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost("register")]
        public async Task<User> Register(UserDto user)
        {
            var createdUser = await _authAppService.CreateUser(new User
            {
                Username = user.Username
            }, user.Password);

            return createdUser;
        }

        [HttpPost("login")]
        public async Task<string> Login(UserDto user)
        {
            User loginUser = await _authAppService.ValidateUser(new User
            {
                Username = user.Username
            }, user.Password);

            return await _authAppService.CreateJwtToken(loginUser);
        }
    }
}
