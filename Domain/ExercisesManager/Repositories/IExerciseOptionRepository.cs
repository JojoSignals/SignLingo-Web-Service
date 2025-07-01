using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Queries.ExerciseOption;
using Domain.Shared.Repository;

namespace Domain.ExercisesManager.Repositories;

public interface IExerciseOptionRepository : IBaseRepository<ExerciseOption>
{
    Task<IReadOnlyCollection<ExerciseOption>> GetExerciseOptionsByExerciseIdAsync(int exerciseId);
}