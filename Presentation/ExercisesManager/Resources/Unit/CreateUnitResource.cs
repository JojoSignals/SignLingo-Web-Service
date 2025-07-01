using System.ComponentModel.DataAnnotations;

namespace Presentation.ExercisesManager.Resources.Unit;

public record CreateUnitResource(
    [Required(ErrorMessage = "El nombre no puede ser nulo.")]
    string Name
);