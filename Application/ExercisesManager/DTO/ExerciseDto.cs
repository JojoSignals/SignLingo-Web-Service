using Domain.ExercisesManager.Model.ValueObjects;

namespace Application.ExercisesManager.DTO;

public record ExerciseDto(
    QuestionType QuestionType,
    int LevelId,
    ICollection<ExerciseOptionDto> ExerciseOptionDtos
);