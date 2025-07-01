using System.ComponentModel.DataAnnotations;

namespace Presentation.ExercisesManager.Resources.Level;

public record CreateLevelResource(
    [Required(ErrorMessage = "La nombre es requerido")]
    string LevelName,
    [Required(ErrorMessage = "La descripcion es requerido")]
    string LevelDescription,
    int ExperienceRequired,
    int TotalQuestions,
    int UnitId,
    int IconId
);