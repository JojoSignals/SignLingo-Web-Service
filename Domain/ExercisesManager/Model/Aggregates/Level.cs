using Domain.ExercisesManager.Model.Entities;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Aggregates;

public class Level : BaseModel
{
    public string LevelName { get; set; }
    public string LevelDescription { get; set; }
    public int ExperienceRequiered { get; set; }
    public int TotalQuestions { get; set; }
    public Unit Unit { get; set; }
    public Icon Icon { get; set; }
    public List<Exercise> Exercises { get; set; }
    
    
    public int UnitId { get; set; }
    public int IconId { get; set; }
}