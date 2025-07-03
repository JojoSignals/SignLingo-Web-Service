namespace Domain.ExercisesManager.Model.Responses;

public class ExerciseOptionResponse
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public OptionResponse Option { get; set; }
    public bool IsCorrect { get; set; }

}

