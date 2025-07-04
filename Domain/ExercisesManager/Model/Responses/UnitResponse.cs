
namespace Domain.ExercisesManager.Model.Responses;

public class UnitResponse
{
  public int Id { get; set; }
  public string Name { get; set; }
  public List<LevelResponse> Levels { get; set; }
}