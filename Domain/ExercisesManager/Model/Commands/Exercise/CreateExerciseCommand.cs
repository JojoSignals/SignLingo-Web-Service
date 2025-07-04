namespace Domain.ExercisesManager.Model.Commands.Exercise;

public record CreateExerciseCommand(
    int QuestionTypeId,
    int LevelId,
    ICollection<int> OptionsId);