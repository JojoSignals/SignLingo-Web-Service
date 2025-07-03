namespace Domain.ExercisesManager.Model.Responses;

public class LevelResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ExperienceRequired { get; set; }
    public UnitResponse Unit { get; set; }
    public IconResponse Icon { get; set; }


    public IReadOnlyCollection<ExerciseResponse> Exercises { get; set; } = [];

}