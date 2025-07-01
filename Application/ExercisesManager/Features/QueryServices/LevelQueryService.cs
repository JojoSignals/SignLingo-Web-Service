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
    private readonly IExerciseOptionRepository _exerciseOptionRepository;

    public LevelQueryService(ILevelRepository levelRepository, IMapper mapper,
        IExerciseOptionRepository exerciseOptionRepository)
    {
        _levelRepository = levelRepository;
        _mapper = mapper;
        _exerciseOptionRepository = exerciseOptionRepository;
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
        var level = await _levelRepository.GetByIdAsync(query.Id);
        if (level == null)
        {
            throw new LevelNotFoundException(query.Id);
        }

        // var response = _mapper.Map<LevelResponse>(unit);

        List<LevelExerciseResponse> levelExerciseResponses = [];
        Console.WriteLine("LevelExercises" + level.Exercises);

        var exerciseIds = level.Exercises.Select(l => l.Id);
        
        Console.WriteLine("ExerciseIds " + JsonSerializer.Serialize(exerciseIds));

        foreach (var exerciseId in exerciseIds)
        {
            var options = await _exerciseOptionRepository.GetExerciseOptionsByExerciseIdAsync(exerciseId);
            levelExerciseResponses.Add(
                new LevelExerciseResponse()
                {
                    ExerciseOptions = options
                }
            );
        }


        var response = new LevelResponse()
        {
            LevelName = level.LevelName,
            Icon = _mapper.Map<IconResponse>(level.Icon),
            Unit = _mapper.Map<UnitResponse>(level.Unit),
            TotalQuestions = level.TotalQuestions,
            ExperienceRequired = level.ExperienceRequiered,
            LevelDescription = level.LevelDescription,
            LevelExercises = levelExerciseResponses
        };


        return response;
    }
}