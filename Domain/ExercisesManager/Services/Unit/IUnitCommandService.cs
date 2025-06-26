using Domain.ExercisesManager.Model.Commands.Unit;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.Unit;

public interface IUnitCommandService
{
    Task<UnitResponse> Handle(CreateUnitCommand command);
    
    Task<bool> Handle(EditUnitCommand command);
    
    Task<bool> Handle(DeleteUnitCommand command);
}