using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.UserStats.Persistence;

public class UserStatRepository(AppDbContext context) : BaseRepository<UserStat>(context), IUserStatsRepository
{
    public async Task<UserStat?> GetByUserIdAsync(int userId)
    {
        return await _context
            .UserStats
            .Include(u => u.UserCompletedExercises)
            .FirstOrDefaultAsync(us => us.UserId == userId);
    }



    protected override IQueryable<UserStat> IncludeNavigationProperties(DbSet<UserStat> dbSet)
    {
        return dbSet.Include(u => u.UserCompletedExercises);
    }

}