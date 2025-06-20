namespace Domain.ExercisesManager.Model.Commands;

public record EditExerciseCommand(
    int Id, 
    string QuestionWord,
    int QuestionTypeId
    );