using Application.Ranking.Features.QueryServices;
using Microsoft.AspNetCore.Mvc;
using Presentation.Ranking.Resources;

namespace Presentation.Ranking.Controllers;

[ApiController]
[Route("api/v1/ranking")]
public class RankingController : ControllerBase
{
    private readonly IRankingQueryService _rankingQueryService;

    public RankingController(IRankingQueryService rankingQueryService)
    {
        _rankingQueryService = rankingQueryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRanking([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _rankingQueryService.GetTopRankingAsync(page, pageSize);
        var resource = result.Select(r => new RankingResource(r.Username, r.Stars));
        return Ok(resource);
    }
}