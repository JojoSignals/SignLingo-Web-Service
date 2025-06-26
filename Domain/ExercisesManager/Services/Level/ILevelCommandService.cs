using Domain.ExercisesManager.Model.Commands.Level;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.Level;

public interface ILevelCommandService
{
    Task<LevelResponse> Handle(CreateLevelCommand command);
    
    Task<bool> Handle(EditLevelCommand command);
    
    Task<bool> Handle(DeleteLevelCommand command);
}