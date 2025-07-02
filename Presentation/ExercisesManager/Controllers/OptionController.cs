using Domain.ExercisesManager.Model.Commands.Option;
using Domain.ExercisesManager.Model.Queries.Option;
using Domain.ExercisesManager.Services.Option;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ExercisesManager.Resources.Option;
using Presentation.ExercisesManager.Transforms.Option;

namespace Presentation.ExercisesManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionCommandService _optionCommandService;
        private readonly IOptionQueryService _optionQueryService;

        public OptionController(IOptionCommandService optionCommandService, IOptionQueryService optionQueryService)
        {
            _optionCommandService = optionCommandService;
            _optionQueryService = optionQueryService;
        }
        
        //GET ALL OPTIONS
        [HttpGet]
        public async Task<IActionResult> GetOption()
        {
            var query = new GetAllOptionsQuery();
            var result = await _optionQueryService.Handle(query);
            return Ok(result);
        }
        
        //GET OPTION BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionByIdAsync(int id)
        {
            var query = new GetOptionByIdQuery(id);
            var result = await _optionQueryService.Handle(query);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        //POST OPTION
        [HttpPost("create-option")]
        public async Task<IActionResult> CreateIconAsync([FromForm] CreateOptionResource resource)
        {
            if (resource == null) return BadRequest();
            if (string.IsNullOrEmpty(resource.Word)) return BadRequest("El campo de 'Word' es Obligatorio");

            var command = CreateOptionCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await _optionCommandService.Handle(command);

            return StatusCode(201, result);
        }
        
        //PATCH OPTION WITH ID
        [HttpPatch("update-option/{id}")]
        public async Task<IActionResult> EditOptionAsync(int id, [FromBody] EditOptionResource resource)
        {
            if(!ModelState.IsValid) return StatusCode(400, "Invalid resource data");
            
            var command = EditOptionCommandFromResourceAssembler.ToCommandFromResource(id, resource);
            
            var result = await _optionCommandService.Handle(command);
            
            return Ok(result);
        }
        
        //DELETE OPTION
        [HttpDelete("delete-option/{id}")]
        public async Task<IActionResult> DeleteOptionAsync(int id)
        {
            var command = new DeleteOptionCommand(id);
            var result = await _optionCommandService.Handle(command);
            
            return Ok(result);
        }
    }
}
