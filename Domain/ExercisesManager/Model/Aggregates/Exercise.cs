using Domain.Shared;

namespace Domain.ExercisesManager.Model.Aggregates;

public class Exercise : BaseModel
{
    public string QuestionWord { get; set; }
    
}