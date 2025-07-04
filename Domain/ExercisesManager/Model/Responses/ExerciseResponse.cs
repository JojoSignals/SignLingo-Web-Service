
namespace Domain.ExercisesManager.Model.Responses;

public class ExerciseResponse
{
    public int Id { get; set; }
    public int QuestionTypeId { get; set; }
    public int LevelId { get; set; }
    public IReadOnlyCollection<ExerciseOptionResponse> ExerciseOptions { get; set; } = [];
    
}