using Domain.ExercisesManager.Model.Aggregates;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Entities;

public class Unit : BaseModel
{
   public string Name { get; set; }
   
   public List<Level>  Levels { get; set; }
}