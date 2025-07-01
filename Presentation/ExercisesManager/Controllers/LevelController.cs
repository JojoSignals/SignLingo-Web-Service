using Domain.ExercisesManager.Model.Commands.Level;
using Domain.ExercisesManager.Model.Queries.Level;
using Domain.ExercisesManager.Services.Level;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ExercisesManager.Resources.Level;
using Presentation.ExercisesManager.Transforms.Level;

namespace Presentation.ExercisesManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
      private readonly ILevelCommandService _levelCommandService;
      private readonly ILevelQueryService _levelQueryService;

      public LevelController(ILevelCommandService levelCommandService, ILevelQueryService levelQueryService)
      {
          _levelCommandService = levelCommandService;
          _levelQueryService = levelQueryService;
      }
      
      //GET ALL LEVELS
      [HttpGet]
      public async Task<IActionResult> GetAllLevelsAsync()
      {
          var query = new GetAllLevelsQuery();
          var result = await _levelQueryService.Handle(query);
          var resources = LevelResourceFromLevelResponseAssembler.ToResourcesFromResponse(result);
          return Ok(resources);
      }
      
      // GET LEVEL BY ID
      [HttpGet("{id}")]
      public async Task<IActionResult> GetLevelByIdAsync(int id)
      {
          var query = new GetLevelByIdQuery(id);
          var result = await _levelQueryService.Handle(query);
          if (result is null) return NotFound();
          var resource = LevelResourceFromLevelResponseAssembler.ToResourceFromResponse(result);
          return Ok(resource);
      }
      
      // POST LEVEL
      [HttpPost("create-level")]
      public async Task<IActionResult> CreateLevelAsync([FromBody] CreateLevelResource resource)
      {
          if (!ModelState.IsValid) return BadRequest(ModelState);
          
          var command = CreateLevelCommandFromResourceAssembler.ToCommandFromResource(resource);
          
          var result = await _levelCommandService.Handle(command);
          var output = LevelResourceFromLevelResponseAssembler.ToResourceFromResponse(result);
          return StatusCode(201, output);
      }
      // PATCH EXERCISE WITH ID
      [HttpPatch("patch/{id}")]
      public async Task<IActionResult> EditLevelAsync(int id, [FromBody] EditLevelResource resource)
      {
          if(!ModelState.IsValid) return StatusCode(400, "Invlid resource data");
          
          var command = EditLevelCommandFromResourceAssembler
              .ToCommandFromResource(id, resource);
          var result = await _levelCommandService.Handle(command);
          
          return Ok(result);
      }
      // DELETE LEVEL
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteLevelAsync(int id)
      {
          var command = new DeleteLevelCommand(id);
          var result = await _levelCommandService.Handle(command);
          return Ok(result);
      }
    }
}
