using Domain.Security.Model.Commands;
using Domain.Security.Model.Queries;
using Domain.Security.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Security.Resources;
using Presentation.Security.Transform;

namespace Presentation.Security.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserCommandService _userCommandService;
        public UserController(IUserQueryService userQueryService, IUserCommandService userCommandService)
        {
            _userCommandService = userCommandService;
            _userQueryService = userQueryService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var query = new GetAllUsersQuery();
            var result = await _userQueryService.Handle(query);
            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _userQueryService.Handle(query);
            return Ok(result);
        }
        
        // PUT api/<UserController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserResource updateUserResource)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid resource data.");

            var command = UpdateUserCommandFromResourceAssembler
                .ToCommandFromResource(id, updateUserResource);
            
            var result = await _userCommandService.Handle(id, command);
            return Ok(result);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserIdAsync(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _userCommandService.Handle(command);
            return Ok(result);
        }


        [HttpPut("{id}/picture")]
        public async Task<IActionResult> UpdateUserProfileAsync(int id, [FromForm] UpdateUserPictureResource resource)
        {
            var command = UpdateUserPictureCommandFromResourceAssembler.ToCommandFromResource(id, resource);

            var result = await _userCommandService.Handle(command);

            return Ok(result);
        }
    }
}
