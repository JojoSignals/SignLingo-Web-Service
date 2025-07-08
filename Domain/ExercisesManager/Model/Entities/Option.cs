using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Shared;

namespace Domain.ExercisesManager.Model.Entities;

public class Option : BaseModel
{
    public string Word { get; set; }
    public string UrlImage { get; set; }
    public MediaType MediaType { get; set; }
    public ICollection<ExerciseOption> ExerciseOptions { get; set; }
}