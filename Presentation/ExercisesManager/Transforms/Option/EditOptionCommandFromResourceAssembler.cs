using Domain.ExercisesManager.Model.Commands.Option;
using Domain.ExercisesManager.Model.ValueObjects;
using Presentation.ExercisesManager.Resources.Option;

namespace Presentation.ExercisesManager.Transforms.Option;

public static class EditOptionCommandFromResourceAssembler
{
    public static EditOptionCommand ToCommandFromResource(int id, EditOptionResource resource)
    {
        if (!Enum.TryParse<MediaType>(resource.MediaType, true, out var mediaType))
        {
            throw new ArgumentException($"Valor inválido para MediaType: {resource.MediaType}");
        }
        return new EditOptionCommand(
            id,
            resource.Word,
            resource.UrlImage,
            mediaType
        );
    }
}