using Application.UserStats.Exceptions;
using AutoMapper;
using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Model.Queries;
using Domain.UserStats.Model.Responses;
using Domain.UserStats.Repositories;
using Domain.UserStats.Services;

namespace Application.UserStats.Features.QueryServices;

public class UserStatQueryService : IUserStatsQueryService
{
    private readonly IUserStatsRepository _repository;
    private readonly IMapper _mapper;

    public UserStatQueryService(IUserStatsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<UserStatsResponse?> Handle(GetUserStatByIdQuery query)
    {
        var stat = await _repository.GetByIdAsync(query.Id);
        return stat is null ? null : _mapper.Map<UserStatsResponse>(stat);
    }

    public async Task<UserStatsResponse?> Handle(GetUserStatsByUserIdQuery query)
    {
        var stat = await _repository.GetByUserIdAsync(query.UserId);
        return stat is null ? null : _mapper.Map<UserStatsResponse>(stat);
    }

    public async Task<IReadOnlyCollection<UserStatsResponse>> Handle(GetAllUserStatsQuery query)
    {
        var stats = await _repository.GetAllAsync();
        return _mapper.Map<IReadOnlyCollection<UserStatsResponse>>(stats);
    }
}