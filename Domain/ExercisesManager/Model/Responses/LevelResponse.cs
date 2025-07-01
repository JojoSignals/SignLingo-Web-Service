using System.Text.Json.Serialization;
using Domain.ExercisesManager.Model.Entities;

namespace Domain.ExercisesManager.Model.Responses;

public class LevelResponse
{
    public string LevelName { get; set; }
    public string LevelDescription { get; set; }
    public int ExperienceRequired { get; set; }
    public int TotalQuestions { get; set; }
    public UnitResponse Unit { get; set; }
    public IconResponse Icon { get; set; }
    
}