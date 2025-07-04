using Domain.Shared.Repository;
using Domain.UserStats.Model.Agreggates;

namespace Domain.UserStats.Repositories;

public interface IUserStatsRepository : IBaseRepository<UserStat>
{
    Task<UserStat?> GetByUserIdAsync(int userId);

}