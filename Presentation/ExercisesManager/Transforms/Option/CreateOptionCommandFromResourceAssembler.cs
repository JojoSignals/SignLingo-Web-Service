using Domain.ExercisesManager.Model.Commands.Option;
using Domain.ExercisesManager.Model.ValueObjects;
using Presentation.ExercisesManager.Resources.Option;

namespace Presentation.ExercisesManager.Transforms.Option;

public static class CreateOptionCommandFromResourceAssembler
{
    public static CreateOptionCommand ToCommandFromResource(CreateOptionResource resource)
    {
        if (!Enum.TryParse<MediaType>(resource.MediaType, true, out var mediaType))
        {
            throw new ArgumentException($"Valor inválido para MediaType: {resource.MediaType}");
        }
        return new CreateOptionCommand(
            resource.Word,
            resource.Image.OpenReadStream(),
            mediaType
        );
    }
}