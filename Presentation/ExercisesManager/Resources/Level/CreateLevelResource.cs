using System.ComponentModel.DataAnnotations;

namespace Presentation.ExercisesManager.Resources.Level;

public record CreateLevelResource(
    [Required(ErrorMessage = "La nombre es requerido")]
    string Name,
    int ExperienceRequired,
    int UnitId,
    int IconId
);