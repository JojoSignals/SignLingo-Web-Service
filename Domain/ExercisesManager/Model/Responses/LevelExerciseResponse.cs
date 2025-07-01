using Domain.ExercisesManager.Model.Aggregates;

namespace Domain.ExercisesManager.Model.Responses;

public class LevelExerciseResponse
{
    public IReadOnlyCollection<ExerciseOption> ExerciseOptions { get; set; }
    
}