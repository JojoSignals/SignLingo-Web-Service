using Domain.Ranking.Model.Entities;
using Domain.Ranking.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ranking.Persistence.EFC.Repositories;

public class RankingRepository : IRankingRepository
{
    private readonly AppDbContext _context;

    public RankingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<RankingEntry>> GetTopRankingAsync(int page, int pageSize)
    {
        return await (from us in _context.UserStats
                join u in _context.Users on us.UserId equals u.Id into userJoin
                from u in userJoin.DefaultIfEmpty()
                orderby us.Stars descending
                select new RankingEntry
                {
                    Id = us.UserId,
                    Stars = us.Stars,
                    Username = u != null ? u.Username : null // tolera usuarios sin username
                })
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

}
