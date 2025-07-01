using Application.UserStats.Features.CommandServices;
using Application.UserStats.Features.QueryServices;
using Domain.UserStats.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.UserStats.Resources;
using Presentation.UserStats.Transforms.Assemblers;

namespace Presentation.UserStats.Controllers;

[ApiController]
[Route("api/v1/userstats")]
public class UserStatController : ControllerBase
{
    private readonly UserStatCommandService _commandService;
    private readonly UserStatQueryService _queryService;

    public UserStatController(UserStatCommandService commandService, UserStatQueryService queryService)
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
        var stat = CreateUserStatCommandAssembler.ToEntity(resource);
        await _commandService.CreateAsync(stat);
        return CreatedAtAction(nameof(GetById), new { id = stat.Id }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateUserStatResource resource)
    {
        var stat = UpdateUserStatCommandAssembler.ToEntity(resource);
        stat.Id = id;
        await _commandService.UpdateAsync(stat);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _commandService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
