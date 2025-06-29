using Domain.Ranking.Model.Entities;

namespace Application.Ranking.Features.QueryServices;

public interface IRankingQueryService
{
    Task<IReadOnlyCollection<RankingEntry>> GetTopRankingAsync(int page, int pageSize);
}