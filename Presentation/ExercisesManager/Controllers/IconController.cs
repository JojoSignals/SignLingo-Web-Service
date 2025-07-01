using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Commands.IconCommands;
using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Model.Queries.IconQueries;
using Domain.ExercisesManager.Services;
using Domain.ExercisesManager.Services.IconServices;
using Domain.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ExercisesManager.Resources;
using Presentation.ExercisesManager.Resources.Icon;
using Presentation.ExercisesManager.Transforms;
using Presentation.ExercisesManager.Transforms.Icon;

namespace Presentation.ExercisesManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IconController : ControllerBase
    {
        private readonly IIconCommandService _iconCommandService;
        private readonly IIconQueryService _iconQueryService;

        public IconController(IIconCommandService iconCommandService, IIconQueryService iconQueryService, IImageManagerService imageManagerService)
        {
            _iconCommandService = iconCommandService;
            _iconQueryService = iconQueryService;
        }
        //GET ALL Icons
        [HttpGet]
        public async Task<IActionResult> GetAllIcons()
        {
            var query = new GetAllIconsQuery();
            var result = await _iconQueryService.Handle(query);
            var resources = IconResourceFromIconResponseAssembler.ToResourcesFromResponse(result);
            return Ok(resources);
        }
        
        //GET ICON BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIconByIdAsync(int id)
        {
            var query = new GetIconByIdQuery(id);
            var result = await _iconQueryService.Handle(query);
            if (result == null) return NotFound();
            var resource = IconResourceFromIconResponseAssembler.ToResourceFromResponse(result);
            return Ok(resource);
        }
        
        //POST ICON
        [HttpPost("create-icon")]
        public async Task<IActionResult> CreateIconAsync([FromForm] CreateIconResource resource)
        {
            if (resource == null) return BadRequest("Invalid resource data");
            // if (string.IsNullOrEmpty(resource.UrlImage)) return BadRequest("EL campo 'urlimage' es obligatorio");

            var command = CreateIconCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await _iconCommandService.Handle(command);
            var output = IconResourceFromIconResponseAssembler.ToResourceFromResponse(result);

            return StatusCode(201, output);
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
