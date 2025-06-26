using Domain.ExercisesManager.Model.Commands.Unit;
using Presentation.ExercisesManager.Resources.Unit;

namespace Presentation.ExercisesManager.Transforms.Unit;

public static class EditUnitCommandFromResourceAssembler
{
    public static EditUnitCommand 
        ToCommandFromResource(int id, EditUnitResource resource) =>
        new EditUnitCommand(
            id,
            resource.Name
        );
    
}