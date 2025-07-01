namespace Presentation.ExercisesManager.Resources.Exercise;

public record ExerciseResource(
    int ExerciseId,
    List<ExerciseOptionResource> ExerciseOptions
    );