namespace Domain.UserStats.Model.Commands;
public record AddExerciseToCompletedCommand(int ExerciseId, bool IsApproved);