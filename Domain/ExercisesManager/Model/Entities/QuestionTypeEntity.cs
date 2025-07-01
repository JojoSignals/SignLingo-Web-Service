using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Entities;

public class QuestionTypeEntity : BaseModel
{
    public QuestionType Qtype { get; set; }
    
    public List<Exercise> Exercise { get; set; }
}