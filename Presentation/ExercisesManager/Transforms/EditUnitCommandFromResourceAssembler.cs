using Domain.ExercisesManager.Model.Commands;
using Presentation.ExercisesManager.Resources;

namespace Presentation.ExercisesManager.Transforms;

public static class EditUnitCommandFromResourceAssembler
{
    public static EditUnitCommand 
        ToCommandFromResource(int id, EditUnitResource resource) =>
        new EditUnitCommand(
            id,
            resource.Name
        );
    
}