namespace Domain.ExercisesManager.Model.Commands.Option;

public record CreateOptionCommand(
        string Word,
        string UrlImage
    );