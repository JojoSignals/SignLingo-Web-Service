namespace Domain.ExercisesManager.Model.Commands;

public record CreateExerciseCommand(
    string QuestionWord,
    int QuestionTypeId
    );