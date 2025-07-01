using Domain.ExercisesManager.Model.Commands.Unit;
using Domain.ExercisesManager.Model.Queries.Unit;
using Domain.ExercisesManager.Services.Unit;
using Microsoft.AspNetCore.Mvc;
using Presentation.ExercisesManager.Resources.Unit;
using Presentation.ExercisesManager.Transforms.Unit;

namespace Presentation.ExercisesManager.Controllers
{
    [Route("api/v1/units")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitCommandService _unitCommandService;
        private readonly IUnitQueryService _unitQueryService;

        public UnitController(IUnitCommandService unitCommandService, IUnitQueryService unitQueryService)
        {
            _unitCommandService = unitCommandService;
            _unitQueryService = unitQueryService;
        }
        // Get ALl Units
        [HttpGet]
        public async Task<IActionResult> GetAllUnitsAsync()
        {
            var query = new GetAllUnitsQuery();
            var responseList = await _unitQueryService.Handle(query);
            var resources = UnitResourceFromUnitResponseAssembler.ToResourcesFromResponses(responseList);
            return Ok(resources);
        }
        
       
        //GET UNIT BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnitByIdAsync(int id)
        {
            var query = new GetUnitByIdQuery(id);
            var result = await _unitQueryService.Handle(query);
            if (result is null) return NotFound();
            var resource = UnitResourceFromUnitResponseAssembler.ToResourceFromResponse(result);
            return Ok(resource);
        }
        
        //POST EXERCISE
        [HttpPost("create-unit")]
        public async Task<IActionResult> CreateUnitAsync([FromBody] CreateUnitResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var command = CreateUnitCommandFromResourceAssembler.ToCommandFromResource(resource);
            
            var result = await _unitCommandService.Handle(command);
            var output = UnitResourceFromUnitResponseAssembler.ToResourceFromResponse(result);

            return StatusCode(201, output);
        }
        
        // PATCH Exercise with Id
        [HttpPatch("patch/{id}")]
        public async Task<IActionResult> EditUnitAsync(int id, [FromBody] EditUnitResource resource)
        {
            if(!ModelState.IsValid) return StatusCode(400, "Invalid resource data");

            var command = EditUnitCommandFromResourceAssembler
                .ToCommandFromResource(id, resource);
            var result = await _unitCommandService.Handle(command);

            return Ok(result);
        }
        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitAsync(int id)
        {
            var command = new DeleteUnitCommand(id);
            var result = await _unitCommandService.Handle(command);
            return Ok(result);
        }
    }
}
