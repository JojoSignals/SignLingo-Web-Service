using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services;

public interface IExerciseCommandService
{
    Task<ExerciseResponse> Handle(CreateExerciseCommand command);
    
    Task<bool> Handle(EditExerciseCommand command);
    
    Task<bool> Handle(DeleteExerciseCommand command);
    
}