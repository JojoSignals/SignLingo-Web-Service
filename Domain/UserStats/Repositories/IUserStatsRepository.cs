using Domain.UserStats.Model.Agreggates;

namespace Domain.UserStats.Repositories;

public interface IUserStatsRepository
{
    Task AddAsync(UserStat userStat);
    Task<UserStat?> GetByIdAsync(int id);
    Task<UserStat?> GetByUserIdAsync(int userId);
    Task<IReadOnlyCollection<UserStat>> GetAllAsync(); // <-- AGREGA ESTO
    Task UpdateAsync(UserStat userStat);
    Task<bool> DeleteAsync(int id);
}