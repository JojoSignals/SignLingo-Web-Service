using Domain.ExercisesManager.Model.ValueObjects;

namespace Domain.ExercisesManager.Model.Commands.Option;

public record CreateOptionCommand(
        string Word,
        Stream Image,
        MediaType MediaType
    );