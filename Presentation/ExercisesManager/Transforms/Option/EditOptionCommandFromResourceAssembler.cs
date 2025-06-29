using Domain.ExercisesManager.Model.Commands.Option;
using Presentation.ExercisesManager.Resources.Option;

namespace Presentation.ExercisesManager.Transforms.Option;

public static class EditOptionCommandFromResourceAssembler
{
    public static EditOptionCommand ToCommandFromResource(int id, EditOptionResource resource)
    {
        return new EditOptionCommand(
            id,
            resource.Word,
            resource.UrlImage
        );
    }
}