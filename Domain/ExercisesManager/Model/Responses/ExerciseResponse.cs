using Domain.ExercisesManager.Model.ValueObjects;

namespace Domain.ExercisesManager.Model.Responses;

public class ExerciseResponse
{
    public string QuestionWord { get; set; }
    public QuestionType QuestionType { get; set; }
    
}