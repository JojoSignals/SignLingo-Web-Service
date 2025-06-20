using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services;

public interface IExerciseQueryService
{
    Task<IReadOnlyCollection<ExerciseResponse>> Handle(GetAllExercisesQuery query);
    Task<ExerciseResponse?> Handle(GetExerciseByIdQuery query);
    
    Task<IReadOnlyCollection<ExerciseResponse>> Handle(GetAllExercisesByQuestionTypeIdQuery query);
}