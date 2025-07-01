using Domain.ExercisesManager.Model.Aggregates;

namespace Domain.ExercisesManager.Model.Responses;

public class UnitResponse
{
  public string Name { get; set; }
  public List<LevelDto> Levels { get; set; }
}