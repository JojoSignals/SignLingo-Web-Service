using Application.UserStats.Features.CommandServices;
using Application.UserStats.Features.QueryServices;
using Domain.UserStats.Model.Agreggates;
using Microsoft.AspNetCore.Mvc;
using Presentation.UserStats.Resources;
using Presentation.UserStats.Transform.Assemblers;

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

    [HttpGet("{id}")]
    public async Task<ActionResult<UserStatResource>> GetById(int id)
    {
        var stat = await _queryService.GetByIdAsync(id);
        if (stat is null) return NotFound();
        return Ok(UserStatResourceAssembler.ToResource(stat));
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<UserStatResource>> GetByUserId(int userId)
    {
        var stat = await _queryService.GetByUserIdAsync(userId);
        return Ok(UserStatResourceAssembler.ToResource(stat));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserStatResource resource)
    {
        var stat = CreateUserStatCommandAssembler.ToEntity(resource);
        await _commandService.CreateAsync(stat);
        return CreatedAtAction(nameof(GetById), new { id = stat.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserStatResource resource)
    {
        var stat = UpdateUserStatCommandAssembler.ToEntity(resource);
        stat.Id = id;
        await _commandService.UpdateAsync(stat);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _commandService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
