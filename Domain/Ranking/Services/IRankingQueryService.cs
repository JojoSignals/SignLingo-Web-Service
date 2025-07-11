using Domain.Ranking.Model.Entities;

namespace Domain.Ranking.Services;

public interface IRankingQueryService
{
    Task<IReadOnlyCollection<RankingEntry>> GetTopRankingAsync(int page, int pageSize, int currentUserId);
}