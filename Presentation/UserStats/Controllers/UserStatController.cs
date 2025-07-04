using Application.UserStats.Features.CommandServices;
using Application.UserStats.Features.QueryServices;
using Domain.UserStats.Model.Commands;
using Domain.UserStats.Model.Queries;
using Domain.UserStats.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.UserStats.Resources;
using Presentation.UserStats.Transforms.Assemblers;

namespace Presentation.UserStats.Controllers;

[ApiController]
[Route("[controller]")]
public class UserStatController : ControllerBase
{
    private readonly IUserStatsCommandService _commandService;
    private readonly IUserStatsQueryService _queryService;

    public UserStatController(IUserStatsCommandService commandService, IUserStatsQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    // Buscar por ID (PK)
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserStatResource>> GetById(int id)
    {
        var query = new GetUserStatByIdQuery(id);
        var stat = await _queryService.Handle(query);

        if (stat is null) return NotFound();
        return Ok(UserStatResourceAssembler.ToResource(stat));
    }

    // Buscar por UserId (FK)
    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<UserStatResource>> GetByUserId(int userId)
    {
        var query = new GetUserStatsByUserIdQuery(userId);
        var stat = await _queryService.Handle(query);

        if (stat is null) return NotFound();
        return Ok(UserStatResourceAssembler.ToResource(stat));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserStatResource>>> GetAll()
    {
        var query = new GetAllUserStatsQuery();
        var stats = await _queryService.Handle(query);

        var resources = stats.Select(UserStatResourceAssembler.ToResource);
        return Ok(resources);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserStatResource resource)
    {
        var command = CreateUserStatCommandFromResourceAssembler.ToCommandFromResource(resource);
        await _commandService.Handle(command);

        return Created();
        //return CreatedAtAction(nameof(GetById), new { id = stat.Id }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateUserStatResource resource)
    {
        var command = UpdateUserStatCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        await _commandService.Handle(command);
        //var stat = UpdateUserStatCommandAssembler.ToEntity(resource);
        //stat.Id = id;
        //await _commandService.UpdateAsync(stat);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserStatsCommand(id);

        await _commandService.Handle(command);
        return NoContent();
    }
}
