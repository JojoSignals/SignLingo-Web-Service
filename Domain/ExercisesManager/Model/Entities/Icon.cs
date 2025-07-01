using Domain.ExercisesManager.Model.Aggregates;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Entities;

public class Icon : BaseModel
{
    public string UrlImage { get; set; }
    
    public List<Level> Levels { get; set; }
}