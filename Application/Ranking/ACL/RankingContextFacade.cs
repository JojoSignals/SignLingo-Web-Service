using Application.Security.ACL; // Asegúrate de agregar este using
using Domain.Ranking.Services;

namespace Application.Ranking.ACL;

public class RankingContextFacade : IRankingContextFacade
{
    private readonly IRankingQueryService _query;

    public RankingContextFacade(IRankingQueryService query)
    {
        _query = query;
    }

    public async Task<IReadOnlyCollection<RankingDto>> FetchRankingAsync(int page, int pageSize)
    {
        var entries = await _query.GetTopRankingAsync(page, pageSize);

        return entries.Select(e => new RankingDto
        {
            UserId = e.Id,
            Username = e.Username,
            ProfilePictureUrl = e.ProfilePictureUrl,
            Stars = e.Stars,
            Position = e.Position,
        }).ToList();
    }
}