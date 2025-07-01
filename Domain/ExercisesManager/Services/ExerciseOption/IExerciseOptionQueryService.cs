using Domain.ExercisesManager.Model.Queries.ExerciseOption;

namespace Domain.ExercisesManager.Services.ExerciseOption;

public interface IExerciseOptionQueryService
{
    Task<IReadOnlyCollection<Model.Aggregates.ExerciseOption>> Handle(GetExerciseOptionsByExerciseId request);
}