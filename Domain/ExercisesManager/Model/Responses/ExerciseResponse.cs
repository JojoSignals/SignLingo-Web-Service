using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.ValueObjects;

namespace Domain.ExercisesManager.Model.Responses;

public class ExerciseResponse
{
    public string QuestionWord { get; set; }
    public int QuestionTypeId { get; set; }
    public int LevelId { get; set; }
}