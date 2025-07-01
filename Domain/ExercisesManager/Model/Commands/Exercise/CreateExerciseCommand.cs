namespace Domain.ExercisesManager.Model.Commands.Exercise;

public record CreateExerciseCommand(
    string QuestionWord,
    int QuestionTypeId,
    int LevelId
    );