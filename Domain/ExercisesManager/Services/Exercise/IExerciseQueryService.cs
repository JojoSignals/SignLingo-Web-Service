using Domain.ExercisesManager.Model.Queries.Exercise;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.Exercise;

public interface IExerciseQueryService
{
    Task<IReadOnlyCollection<ExerciseResponse>> Handle(GetAllExercisesQuery query);
    Task<ExerciseResponse?> Handle(GetExerciseByIdQuery query);
    
    Task<IReadOnlyCollection<ExerciseResponse>> Handle(GetAllExercisesByQuestionTypeIdQuery query);
}