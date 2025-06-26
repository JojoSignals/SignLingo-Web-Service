using Domain.ExercisesManager.Model.Commands.IconCommands;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.IconServices;

public interface IIconCommandService
{
    Task<IconResponse> Handle(CreateIconCommand command);
    
    Task<bool> Handle(EditIconCommand command);
    
    Task<bool> Handle(DeleteIconCommand command);
}