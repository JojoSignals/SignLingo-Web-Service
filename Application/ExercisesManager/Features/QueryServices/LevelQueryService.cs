using System.Text.Json;
using Application.ExercisesManager.Exceptions.Level;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Queries.Level;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Level;


namespace Application.ExercisesManager.Features.QueryServices;

public class LevelQueryService : ILevelQueryService
{
    private readonly ILevelRepository _levelRepository;
    private readonly IMapper _mapper;

    public LevelQueryService(ILevelRepository levelRepository, IMapper mapper)
    {
        _levelRepository = levelRepository;
        _mapper = mapper;
    }

    //GET ALL LEVELS
    public async Task<IReadOnlyCollection<LevelResponse>> Handle(GetAllLevelsQuery query)
    {
        var levels = await _levelRepository.GetAllAsync();
        
        var response = _mapper.Map<IReadOnlyCollection<LevelResponse>>(levels);
        return response;
    }

    public async Task<LevelResponse?> Handle(GetLevelByIdQuery query)
    {
        var unit = await _levelRepository.GetByIdAsync(query.Id);
        if (unit == null)
        {
            throw new LevelNotFoundException(query.Id);
        }
        
        var response = _mapper.Map<LevelResponse>(unit);
        return response;
    }
}