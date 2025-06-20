using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Shared.Repository;

namespace Domain.ExercisesManager.Repositories;

public interface IExerciseRepository : IBaseRepository<Exercise>
{
   Task<IReadOnlyCollection<Exercise>> GetAllExercisesByQuestionTypeIdAsync(int questionTypeId);
}