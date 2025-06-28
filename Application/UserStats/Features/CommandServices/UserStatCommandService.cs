using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Repositories;
using Domain.Shared.Repository;

namespace Application.UserStats.Features.CommandServices;

public class UserStatCommandService
{
    private readonly IUserStatsRepository _userStatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserStatCommandService(IUserStatsRepository userStatRepository, IUnitOfWork unitOfWork)
    {
        _userStatRepository = userStatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(UserStat userStat)
    {
        await _userStatRepository.AddAsync(userStat);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(UserStat userStat)
    {
        await _userStatRepository.UpdateAsync(userStat);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _userStatRepository.DeleteAsync(id);
        if (deleted)
            await _unitOfWork.CompleteAsync();
        return deleted;
    }
}