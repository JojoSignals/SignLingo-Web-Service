using Domain.ExercisesManager.Model.Entities;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Aggregates;

public class ExerciseOption : BaseModel
{
    public int ExerciseId { get; set; }
    public int OptionId { get; set; }
    public bool IsCorrect { get; set; }
    
    public Exercise Exercise { get; set; }
    public Option Option { get; set; }
}