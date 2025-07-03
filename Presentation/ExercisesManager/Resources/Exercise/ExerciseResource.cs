
using Presentation.ExercisesManager.Resources.ExerciseOption;

namespace Presentation.ExercisesManager.Resources.Exercise;

public record ExerciseResource(
    int Id,
    IReadOnlyCollection<ExerciseOptionResource> Options
    );