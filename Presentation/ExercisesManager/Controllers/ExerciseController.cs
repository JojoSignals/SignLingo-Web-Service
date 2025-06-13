using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ExercisesManager.Resources;
using Presentation.ExercisesManager.Transforms;

namespace Presentation.ExercisesManager.Controllers
{
    [Route("api/v1/exercises")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        
        private readonly IExerciseQueryService _exerciseQueryService;
        private readonly IExerciseCommandService _exerciseCommandService;
        
        // GET: api/<ExerciseController>
        //ALL EXERCISES
        [HttpGet]
        public async Task<IActionResult> GetALlExercisesAsync()
        {
            var query = new GetAllExercisesQuery();
            var result = await _exerciseQueryService.Handle(query);
            
            return Ok(result);
        }

        // GET api/<ExerciseController>/5
        //GET EXERCISE BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseByIdAsync(int id)
        {
            var query = new GetExerciseByIdQuery(id);
            var result = await _exerciseQueryService.Handle(query);
            
            return Ok(result);
        }
       
        // DIEGOOOOOOOOOOOOOOO
        // POST api/<ExerciseController>
        [HttpPost("createExercise")]
        public async Task<IActionResult> CreateExerciseAsync([FromBody] CreateExerciseResource resource)
        {
            if (resource == null)
            {
                return BadRequest("El recurso enviado no puede ser nulo.");
            }

            // Validación explícita para QuestionWord (necesaria aunque sea required en el record)
            if (string.IsNullOrEmpty(resource.QuestionWord))
            {
                return BadRequest("El campo 'QuestionWord' es obligatorio.");
            }
            
            var command = CreateExerciseCommandFromResourceAssembler
                .ToCommandFromResource(resource);
            
            var result = await _exerciseCommandService.Handle(command);
            
            return StatusCode(201, result);
        }

        // PATCH api/<ExerciseController>/5
        [HttpPatch("patch/{id}")]
        public async Task<IActionResult> EditExerciseAsync(int id, [FromBody] EditExerciseResource resource)
        {
            if(!ModelState.IsValid) return StatusCode(400, "Invalid resource data");
            
            var command = EditExerciseCommandFromResourceAssembler
                .ToCommandFromResource(id, resource);
            var result = await _exerciseCommandService.Handle(command);
            
            return Ok(result);
        }

        // DELETE api/<ExerciseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseAsync(int id)
        {
            var command = new DeleteExerciseCommand(id);
            var restult = await _exerciseCommandService.Handle(command);
            return Ok(restult);
        }
    }
}
