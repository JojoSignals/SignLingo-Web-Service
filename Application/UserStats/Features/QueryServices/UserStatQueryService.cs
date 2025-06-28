using Application.UserStats.Exceptions;
using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Repositories;

namespace Application.UserStats.Features.QueryServices;

public class UserStatQueryService
{
    private readonly IUserStatsRepository _repository;

    public UserStatQueryService(IUserStatsRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserStat> GetByUserIdAsync(int userId)
    {
        var stat = await _repository.GetByUserIdAsync(userId);
        if (stat is null)
            throw new UserStatNotFoundException(userId);

        return stat;
    }

    public async Task<IReadOnlyCollection<UserStat>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<UserStat?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}