using Kodlama.io.Devs.Application.Features.Authentication.Commands.Register;
using Kodlama.io.Devs.Application.Features.Authentication.Dtos;
using Kodlama.io.Devs.Application.Features.Authentication.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            UserRegisterDto userRegisterDto = await Mediator.Send(registerCommand);
            return Ok(userRegisterDto);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
        {
            UserLoginDto userLoginDto = await Mediator.Send(loginQuery);
            return Ok(userLoginDto);
        }
    }
}
