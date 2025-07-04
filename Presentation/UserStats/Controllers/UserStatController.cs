using Application.Shared.Features.OutboundServices.ACL;
using Application.UserStats.Features.CommandServices;
using Application.UserStats.Features.QueryServices;
using Domain.UserStats.Model.Commands;
using Domain.UserStats.Model.Queries;
using Domain.UserStats.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.UserStats.Resources;
using Presentation.UserStats.Transforms.Assemblers;

namespace Presentation.UserStats.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserStatController : ControllerBase
{
    private readonly IUserStatsCommandService _commandService;
    private readonly IUserStatsQueryService _queryService;
    private readonly IExternalSecurityService _externalSecurityService;

    public UserStatController(IUserStatsCommandService commandService, IUserStatsQueryService queryService, IExternalSecurityService externalSecurityService)
    {
        _commandService = commandService;
        _queryService = queryService;
        _externalSecurityService = externalSecurityService;
    }


    // Buscar por UserId (FK)
    [HttpGet]
    public async Task<ActionResult<UserStatResource>> GetByUserId()
    {
        try
        {
            var userId = _externalSecurityService.GetCurrentUserId();

            var query = new GetUserStatsByUserIdQuery((int)userId);
            var stat = await _queryService.Handle(query);

            if (stat is null) return NotFound();
            return Ok(UserStatResourceAssembler.ToResource(stat));
        }
        catch (ArgumentNullException err)
        {
            return BadRequest(err.Message);
        }

    }

    [HttpPost("validate-exercise/{id:int}")]
    public async Task<IActionResult> ValidateExercise(int id, [FromBody] ValidateExerciseResource resource)
    {
        if (resource.IsApproved)
        {
            var command = new AddExerciseToCompletedCommand(id);
            await _commandService.Handle(command);
        }
        else
        {
            var command = new LostLiveCommand();
            await _commandService.Handle(command);
        }

        return NoContent();
    }
}
