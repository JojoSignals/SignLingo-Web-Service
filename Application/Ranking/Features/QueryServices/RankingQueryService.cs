using Domain.Ranking.Model.Entities;
using Domain.Ranking.Repositories;
using Domain.Ranking.Services;

namespace Application.Ranking.Features.QueryServices;

public class RankingQueryService : IRankingQueryService
{
    private readonly IRankingRepository _repo;

    public RankingQueryService(IRankingRepository repo)
    {
        _repo = repo;
    }

    public Task<IReadOnlyCollection<RankingEntry>> GetTopRankingAsync(int page, int pageSize, int currentUserId)
        => _repo.GetTopRankingAsync(page, pageSize, currentUserId);
}