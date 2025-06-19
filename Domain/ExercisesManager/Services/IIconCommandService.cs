using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services;

public interface IIconCommandService
{
    Task<IconResponse> Handle(CreateIconCommand command);
    
    Task<bool> Handle(EditIconCommand command);
    
    Task<bool> Handle(DeleteIconCommand command);
}