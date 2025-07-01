using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Queries.ExerciseOption;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.ExerciseOption;

namespace Application.ExercisesManager.Features.QueryServices;

public class ExerciseOptionQueryService : IExerciseOptionQueryService
{
    private readonly IExerciseOptionRepository _exerciseOptionRepository;

    public ExerciseOptionQueryService(IExerciseOptionRepository exerciseOptionRepository)
    {
        _exerciseOptionRepository = exerciseOptionRepository;
    }
    
    public async Task<IReadOnlyCollection<ExerciseOption>> Handle(GetExerciseOptionsByExerciseId request)
    {
        var exerciseOptions = await _exerciseOptionRepository.GetExerciseOptionsByExerciseIdAsync(request.ExerciseId);
        
        return exerciseOptions;
    }
}