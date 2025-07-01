namespace Presentation.ExercisesManager.Resources.Exercise;

public record ExerciseOptionResource(
    int OptionId,
    string Word,
    string Url,
    bool IsCorrect
    );