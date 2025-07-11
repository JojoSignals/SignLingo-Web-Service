using Application.Security.ACL; // Asegúrate de agregar este using
using Domain.Ranking.Services;

namespace Application.Ranking.ACL;

public class RankingContextFacade : IRankingContextFacade
{
    private readonly IRankingQueryService _query;
    private readonly ISecurityContextFacade _security;

    public RankingContextFacade(IRankingQueryService query, ISecurityContextFacade security)
    {
        _query = query;
        _security = security;
    }

    public async Task<IReadOnlyCollection<RankingDto>> FetchRankingAsync(int page, int pageSize)
    {
        int currentUserId = _security.FetchUserIdByToken("token"); // ⚠️ Solo si manejas token directamente aquí
        // Idealmente obtén el userId desde IExternalSecurityService si estás en capa Presentation

        var entries = await _query.GetTopRankingAsync(page, pageSize, currentUserId);

        return entries.Select(e => new RankingDto
        {
            UserId = e.Id,
            Username = e.Username,
            ProfilePictureUrl = e.ProfilePictureUrl,
            Stars = e.Stars,
            Position = e.Position,
            IsCurrentUser = e.IsCurrentUser
        }).ToList();
    }
}