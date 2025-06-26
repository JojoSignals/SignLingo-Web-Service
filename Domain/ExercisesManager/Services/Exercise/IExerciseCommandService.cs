using Domain.ExercisesManager.Model.Commands.Exercise;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.Exercise;

public interface IExerciseCommandService
{
    Task<ExerciseResponse> Handle(CreateExerciseCommand command);
    
    Task<bool> Handle(EditExerciseCommand command);
    
    Task<bool> Handle(DeleteExerciseCommand command);
    
}