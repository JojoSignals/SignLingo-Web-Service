using Application.Ranking.ACL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Ranking.Controllers;
[Authorize]
[ApiController]
[Route("ranking")]
public class RankingController : ControllerBase
{
    private readonly IRankingContextFacade _facade;

    public RankingController(IRankingContextFacade facade) => _facade = facade;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]int page = 1, [FromQuery]int pageSize = 5)
    {
        var ranking = await _facade.FetchRankingAsync(page, pageSize);
        return Ok(ranking);
    }
}