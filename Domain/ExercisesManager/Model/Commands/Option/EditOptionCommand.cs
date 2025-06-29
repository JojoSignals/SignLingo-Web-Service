namespace Domain.ExercisesManager.Model.Commands.Option;

public record EditOptionCommand(
    int Id,
    string Word,
    string UrlImage
    );