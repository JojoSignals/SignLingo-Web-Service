using Domain.ExercisesManager.Model.ValueObjects;

namespace Presentation.ExercisesManager.Resources.Exercise;

public record ExerciseResource(
    int ExerciseId,
    int QuestionType,
    List<ExerciseOptionResource> ExerciseOptions
    );