using Domain.ExercisesManager.Model.Entities;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Aggregates;

public class Level : BaseModel
{
    public string Name { get; set; }
    public int ExperienceRequired { get; set; }
    public List<Exercise> Exercises { get; set; } = [];

    public Unit Unit { get; set; }
    public int UnitId { get; set; }
    public Icon Icon { get; set; }
    public int IconId { get; set; }
}