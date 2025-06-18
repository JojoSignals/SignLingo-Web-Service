using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services;

public interface IUnitCommandService
{
    Task<UnitResponse> Handle(CreateUnitCommand command);
    
    Task<bool> Handle(EditUnitCommand command);
    
    Task<bool> Handle(DeleteUnitCommand command);
}