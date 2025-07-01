using Domain.ExercisesManager.Model.Commands.Option;
using Presentation.ExercisesManager.Resources.Option;

namespace Presentation.ExercisesManager.Transforms.Option;

public static class CreateOptionCommandFromResourceAssembler
{
    public static CreateOptionCommand ToCommandFromResource(CreateOptionResource resource)
    {
        return new CreateOptionCommand(
            resource.Word,
            resource.Image.OpenReadStream()
        );
    }
}