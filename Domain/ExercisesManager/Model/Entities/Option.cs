using Domain.Shared;

namespace Domain.ExercisesManager.Model.Entities;

public class Option : BaseModel
{
    public string Word { get; set; }
    public string UrlImage { get; set; }
}