using Domain.ExercisesManager.Model.Queries.Level;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.Level;

public interface ILevelQueryService
{
    Task<IReadOnlyCollection<LevelResponse>> Handle(GetAllLevelsQuery query);
    
    Task<LevelResponse?> Handle(GetLevelByIdQuery query);
}