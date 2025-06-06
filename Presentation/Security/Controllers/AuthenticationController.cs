using Domain.Security.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Security.Resources;
using Presentation.Security.Transform;

namespace Presentation.Security.Controllers
{
    [Route("api/v1/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserCommandService _userCommandService;
        public AuthenticationController(IUserCommandService userCommandService)
        {
            _userCommandService = userCommandService;
        }
        // GET: api/<AuthenticationController>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] SignUpResource signUpResource)
        {
            var command = SignUpCommandFromResourceAssembler
                .ToCommandFromResource(signUpResource);
            
            var result =  await _userCommandService.Handle(command);
            
            return StatusCode(201, result);
        }

        // GET api/<AuthenticationController>/5
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] SignInResource signInResource)
        {
            var command = SignInCommandFromResourceAssembler
                .ToCommandFromResource(signInResource);

            var result = await _userCommandService.Handle(command);

            return Ok(new
            {
                message = "User logged in successfully",
                token = result.token,
                userId = result.user.Id
            });
        }
    }
}
