namespace Presentation.ExercisesManager.Resources.Exercise;

public record CreateExerciseResource(
    int QuestionTypeId,
    int LevelId,
    ICollection<int> OptionsId);