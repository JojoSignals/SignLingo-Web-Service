using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserStats.Persistence;

public class UserStatRepository : BaseRepository<UserStat>, IUserStatsRepository
{
    public UserStatRepository(AppDbContext context) : base(context) { }

    public async Task<UserStat?> GetByUserIdAsync(int userId)
    {
        return await _context.UserStats
            .Where(us => us.UserId == userId && us.IsEnable)
            .FirstOrDefaultAsync();
    }
}