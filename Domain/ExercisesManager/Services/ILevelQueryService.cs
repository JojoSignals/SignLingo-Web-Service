using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services;

public interface ILevelQueryService
{
    Task<IReadOnlyCollection<LevelResponse>> Handle(GetAllLevelsQuery query);
    
    Task<LevelResponse?> Handle(GetLevelByIdQuery query);
}