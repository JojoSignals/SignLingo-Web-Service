using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Repositories;
using Domain.Shared.Repository;
using Domain.UserStats.Services;
using Domain.UserStats.Model.Responses;
using Domain.UserStats.Model.Commands;
using Domain.UserStats.Model.ValueObjects;
using AutoMapper;
using Application.Shared.Features.OutboundServices.ACL;

namespace Application.UserStats.Features.CommandServices;

public class UserStatCommandService : IUserStatsCommandService
{
    private readonly IUserStatsRepository _userStatRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IExternalSecurityService _externalSecurityService;

    public UserStatCommandService(IUserStatsRepository userStatRepository, IUnitOfWork unitOfWork, IMapper mapper, IExternalSecurityService externalSecurityService)
    {
        _userStatRepository = userStatRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _externalSecurityService = externalSecurityService;
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

    public async Task<bool> Handle(AddExerciseToCompletedCommand command)
    {

        var userId = _externalSecurityService.GetCurrentUserId() ?? throw new ArgumentNullException("UserId not registered");

        var entity = await _userStatRepository.GetByUserIdAsync(userId);

        if (entity == null)
            return false;

        // 1) Comprueba si ya existe
        var already = entity.UserCompletedExercises
                            .Any(x => x.ExerciseId == command.ExerciseId);
        if (!already)
        {
            // 2) S�lo si no existe, lo agregas
            var newCompleted = new UserCompletedExercise
            {
                ExerciseId = command.ExerciseId,
                UserStatId = entity.Id
            };
            entity.UserCompletedExercises.Add(newCompleted);

            await _userStatRepository.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        return true;

    }

    public async Task<bool> Handle(LostLiveCommand command)
    {
        try
        {
            var userId = _externalSecurityService.GetCurrentUserId() ?? throw new ArgumentNullException("UserId not registered");

            var entity = await _userStatRepository.GetByUserIdAsync(userId);

            if (entity == null) return false;

            if (entity.Lives > 0)
            {
                entity.TotalLivesLost += 1;
                entity.Lives -= 1;
            }

            await _userStatRepository.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task IncreaseLivesAsync(CancellationToken cancellationToken)
    {
        var users = await _userStatRepository.GetAllWithLessThanMaxLivesAsync(5, cancellationToken);

        foreach (var user in users)
        {
            user.Lives += 1;
        }

        await _userStatRepository.UpdateRangeAsync(users); 
        await _unitOfWork.CompleteAsync();
    }
}