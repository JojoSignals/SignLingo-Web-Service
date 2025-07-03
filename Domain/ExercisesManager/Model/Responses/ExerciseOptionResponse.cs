namespace Domain.ExercisesManager.Model.Responses;

public class ExerciseOptionResponse
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public int OptionId { get; set; }
    public int IsCorrect { get; set; }

}

