using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Aggregates;

public class Exercise : BaseModel
{
    public string QuestionWord { get; set; }
    public QuestionTypeEntity QuestionType { get; set; }
    public Level Level { get; set; }
    
    public int QuestionTypeId { get; set; }
    public int LevelId { get; set; }
    
    
    
    public ICollection<ExerciseOption> ExerciseOptions { get; set; }
}