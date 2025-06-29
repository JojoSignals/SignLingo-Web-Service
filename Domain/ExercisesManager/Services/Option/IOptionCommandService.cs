using Domain.ExercisesManager.Model.Commands.Option;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.Option;

public interface IOptionCommandService
{
    Task<OptionResponse> Handle(CreateOptionCommand command);
    
    Task<bool> Handle(EditOptionCommand command);
    
    Task<bool> Handle(DeleteOptionCommand command);
}