using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Repositories;
using Domain.Shared.Repository;
using Domain.UserStats.Services;
using Domain.UserStats.Model.Responses;
using Domain.UserStats.Model.Commands;
using AutoMapper;

namespace Application.UserStats.Features.CommandServices;

public class UserStatCommandService : IUserStatsCommandService
{
    private readonly IUserStatsRepository _userStatRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserStatCommandService(IUserStatsRepository userStatRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userStatRepository = userStatRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

    public async Task<UserStatsResponse> Handle(CreateUserStatsCommand command)
    {
        var userStat = new UserStat() { UserId = command.UserId };

        await _userStatRepository.AddAsync(userStat);
        await _unitOfWork.CompleteAsync();

        var userStatEntity = _userStatRepository.GetByIdAsync(command.UserId);

        var response = _mapper.Map<UserStatsResponse>(userStatEntity);


        return response;
    }


    public Task<UserStatsResponse> Handle(UpdateUserStatsCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Handle(DeleteUserStatsCommand command)
    {
        try
        {
            await _userStatRepository.DeleteAsync(command.Id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}