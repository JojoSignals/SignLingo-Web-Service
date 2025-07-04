using AutoMapper;
using Domain.ExercisesManager.Model.Queries.Level;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Level;


namespace Application.ExercisesManager.Features.QueryServices;

public class LevelQueryService(ILevelRepository levelRepository, IMapper mapper, IExerciseOptionRepository exerciseOptionRepository) : ILevelQueryService
{
    private readonly ILevelRepository _levelRepository = levelRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IExerciseOptionRepository _exerciseOptionRepository = exerciseOptionRepository;

    //GET ALL LEVELS
    public async Task<IReadOnlyCollection<LevelResponse>> Handle(GetAllLevelsQuery query)
    {
        var levels = await _levelRepository.GetAllAsync();

        Console.WriteLine("Levels " + levels);

        var response = _mapper.Map<IReadOnlyCollection<LevelResponse>>(levels);
        return response;
    }

    public async Task<LevelResponse?> Handle(GetLevelByIdQuery query)
    {
        var level = await _levelRepository.GetByIdAsync(query.Id);
        if (level == null) return null;

        var response = _mapper.Map<LevelResponse>(level);
        return response;
    }
}