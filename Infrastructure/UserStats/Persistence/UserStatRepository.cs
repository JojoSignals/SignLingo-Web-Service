using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Shared.Persistence.EFC.Configuration;

namespace Infrastructure.UserStats.Persistence;

public class UserStatRepository : IUserStatsRepository
{
    private readonly AppDbContext _context;

    public UserStatRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyCollection<UserStat>> GetAllAsync()
    {
        return await _context.UserStats.ToListAsync();
    }

    public async Task AddAsync(UserStat userStat)
    {
        await _context.UserStats.AddAsync(userStat);
    }

    public async Task<UserStat?> GetByIdAsync(int id)
    {
        return await _context.UserStats.FindAsync(id);
    }

    public async Task<UserStat?> GetByUserIdAsync(int userId)
    {
        return await _context
            .UserStats
            .FirstOrDefaultAsync(us => us.UserId == userId);
    }
    

    public async Task UpdateAsync(UserStat userStat)
    {
        _context.UserStats.Update(userStat);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var stat = await GetByIdAsync(id);
        if (stat is null) return false;
        _context.UserStats.Remove(stat);
        return true;
    }
}