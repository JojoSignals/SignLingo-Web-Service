namespace Application.ExercisesManager.DTO;

public record ExerciseOptionDto(
    int ExerciseId,
    int OptionId,
    bool IsCorrect
);