using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SourceControlProject.Dtos.ApplicationUser;
using SourceControlProject.Service.ApplicationUserService.Interfaces;

namespace SourceControlProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {

        private readonly IApplicationUserService userService;

        public ApplicationUserController(IApplicationUserService service)
        {
            this.userService= service;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isRegistered = await userService.RegisterUserAsync(userDto.UserName, userDto.Email, userDto.Password);

            if (!isRegistered)
                return Conflict("User with the same username or email already exists."); //If time is left this should be put in the common project as a text constants

            return Ok("User registered successfully"); //If time is left this should be put in the common project as a text constants
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginUserDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isValidUser = await userService.ValidateUserCredentialsAsync(loginDto.UserName, loginDto.Password);

            if (!isValidUser)
                return Unauthorized("Invalid username or password."); //If time is left this should be put in the common project as a text constants

            return Ok("Login successful"); //If time is left this should be put in the common project as a text constants
        }
    }
}
