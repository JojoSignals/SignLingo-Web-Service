using Domain.ExercisesManager.Model.Commands.Exercise;
using Domain.ExercisesManager.Model.Queries.Exercise;
using Domain.ExercisesManager.Model.Queries.ExerciseOption;
using Domain.ExercisesManager.Services.Exercise;
using Domain.ExercisesManager.Services.ExerciseOption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ExercisesManager.Resources.Exercise;
using Presentation.ExercisesManager.Transforms.Exercise;

namespace Presentation.ExercisesManager.Controllers
{
    [Route("api/v1/exercises")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        
        private readonly IExerciseQueryService _exerciseQueryService;
        private readonly IExerciseCommandService _exerciseCommandService;
        private readonly IExerciseOptionQueryService _exerciseOptionQueryService;


        public ExerciseController(IExerciseQueryService exerciseQueryService,
            IExerciseCommandService exerciseCommandService,
            IExerciseOptionQueryService exerciseOptionQueryService)
        {
            _exerciseQueryService = exerciseQueryService;
            _exerciseCommandService = exerciseCommandService;
            _exerciseOptionQueryService = exerciseOptionQueryService;
        }
        
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
            var query = new GetExerciseOptionsByExerciseId(id);
            var result = await _exerciseOptionQueryService.Handle(query);
            var output = ExerciseResourceFromExerciseOptionDomainAssembler.ToResourceFromDomain(result);
            
            return Ok(output);
        }
       
        //GET EXERCISE BY QuestionTypeID
        [HttpGet("get-by-questiontype/{id}")]
        public async Task<IActionResult> GetExerciseByQuestionTypeIdAsync(int id)
        {
            var query = new GetAllExercisesByQuestionTypeIdQuery(id);
            var result = await _exerciseQueryService.Handle(query);
            
            return Ok(result);
        }
        
        // DIEGOOOOOOOOOOOOOOO
        // POST api/<ExerciseController>
        [HttpPost("create-exercise")]
        public async Task<IActionResult> CreateExerciseAsync([FromBody] CreateExerciseResource resource)
        {
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
