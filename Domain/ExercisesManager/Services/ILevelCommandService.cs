using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services;

public interface ILevelCommandService
{
    Task<LevelResponse> Handle(CreateLevelCommand command);
    
    Task<bool> Handle(EditLevelCommand command);
    
    Task<bool> Handle(DeleteLevelCommand command);
}