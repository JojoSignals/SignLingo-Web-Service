using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Aggregates;

public class Exercise : BaseModel
{
    public string QuestionWord { get; set; }
    public QuestionTypeEntity QuestionType { get; set; }
    
    public int QuestionTypeId { get; set; }
}