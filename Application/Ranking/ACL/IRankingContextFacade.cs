namespace Application.Ranking.ACL;

public interface IRankingContextFacade
{
    Task<IReadOnlyCollection<RankingDto>> FetchRankingAsync(int page, int pageSize);
}