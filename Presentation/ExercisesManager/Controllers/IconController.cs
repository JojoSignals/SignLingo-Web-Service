using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ExercisesManager.Resources;
using Presentation.ExercisesManager.Transforms;

namespace Presentation.ExercisesManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IconController : ControllerBase
    {
        private readonly IIconCommandService _iconCommandService;
        private readonly IIconQueryService _iconQueryService;

        public IconController(IIconCommandService iconCommandService, IIconQueryService iconQueryService)
        {
            _iconCommandService = iconCommandService;
            _iconQueryService = iconQueryService;
        }
        //GET ALL Icons
        [HttpGet]
        public async Task<IActionResult> GetIcon()
        {
            var query = new GetAllIconsQuery();
            var result = await _iconQueryService.Handle(query);
            return Ok(result);
        }
        
        //GET ICON BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIconByIdAsync(int id)
        {
            var query = new GetIconByIdQuery(id);
            var result = await _iconQueryService.Handle(query);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        //POST ICON
        [HttpPost("create-icon")]
        public async Task<IActionResult> CreateIconAsync([FromBody] CreateIconResource resource)
        {
            if (resource == null) return BadRequest("Invalid resource data");
            if (string.IsNullOrEmpty(resource.UrlImage)) return BadRequest("EL campo 'urlimage' es obligatorio");

            var command = CreateIconCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await _iconCommandService.Handle(command);

            return StatusCode(201, result);
        }
        
        //PATCH ICONS WITH ID
        [HttpPatch("patch/{id}")]
        public async Task<IActionResult> EditIconAsync(int id, [FromBody] EditIconResource questionWord)
        {
            if(!ModelState.IsValid) return StatusCode(400, "Invalid resource data");
            
            var command = EditIconCommandFromResourceAssembler
                .ToCommandFromResource(id, questionWord);
            var result = await _iconCommandService.Handle(command);
            
            return Ok(result);
        }
        
        // DELETE api/<IconController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteIconCommand(id);
            var result = await _iconCommandService.Handle(command);
            
            return Ok(result);
        }
    }
}
