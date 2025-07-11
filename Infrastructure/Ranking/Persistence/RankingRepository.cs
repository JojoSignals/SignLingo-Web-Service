using Domain.Ranking.Model.Entities;
using Domain.Ranking.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ranking.Persistence;

public class RankingRepository : IRankingRepository
{
    private readonly AppDbContext _context;

    public RankingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<RankingEntry>> GetTopRankingAsync(int page, int pageSize, int currentUserId)
    {
        var joinedQuery = _context.UserStats
            .Join(_context.Users,
                stat => stat.UserId,
                user => user.Id,
                (stat, user) => new
                {
                    user.Id,
                    user.Username,
                    user.ProfilePictureUrl,
                    stat.Stars
                })
            .OrderByDescending(x => x.Stars)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsEnumerable() // ¡Importante! Pasamos a memoria para usar índice manual
            .Select((x, idx) => new RankingEntry
            {
                Id = x.Id,
                Username = x.Username,
                ProfilePictureUrl = x.ProfilePictureUrl ?? string.Empty,
                Stars = x.Stars,
                Position = idx + 1 + ((page - 1) * pageSize),
                IsCurrentUser = x.Id == currentUserId
            });

        return joinedQuery.ToList();
    }
}