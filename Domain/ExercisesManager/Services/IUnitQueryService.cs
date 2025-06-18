using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services;

public interface IUnitQueryService
{
    Task<IReadOnlyCollection<UnitResponse>> Handle(GetAllUnitsQuery query);
    Task<ExerciseResponse?> Handle(GetUnitByIdQuery query);
}