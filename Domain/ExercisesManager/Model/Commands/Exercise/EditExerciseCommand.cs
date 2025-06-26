namespace Domain.ExercisesManager.Model.Commands.Exercise;

public record EditExerciseCommand(
    int Id, 
    string QuestionWord,
    int QuestionTypeId
    );