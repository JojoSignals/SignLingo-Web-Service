namespace Presentation.ExercisesManager.Resources.Exercise;

public record CreateExerciseResource(
    string QuestionWord,
    int QuestionTypeId,
    int LevelId,
    ICollection<int> OptionsId);