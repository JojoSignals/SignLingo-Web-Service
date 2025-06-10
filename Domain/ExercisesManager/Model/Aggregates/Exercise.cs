using Domain.Shared;

namespace Domain.ExercisesManager.Model.Aggregates;

public class Exercise : BaseModel
{
    public int QuestionWord { get; set; }
    
}