using Domain.Ranking.Model.Entities;

namespace Domain.Ranking.Repositories;

public interface IRankingRepository
{
    Task<IReadOnlyCollection<RankingEntry>> GetTopRankingAsync(int page, int pageSize);
}