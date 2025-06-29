using Application.Ranking.Features.QueryServices;
using Domain.Ranking.Model.Entities;
using Domain.Ranking.Repositories;

namespace Application.Ranking.Features.QueryServices;

public class RankingQueryService : IRankingQueryService
{
    private readonly IRankingRepository _rankingRepository;

    public RankingQueryService(IRankingRepository rankingRepository)
    {
        _rankingRepository = rankingRepository;
    }

    public async Task<IReadOnlyCollection<RankingEntry>> GetTopRankingAsync(int page, int pageSize)
    {
        return await _rankingRepository.GetTopRankingAsync(page, pageSize);
    }
}