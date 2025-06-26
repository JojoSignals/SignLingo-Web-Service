using Domain.ExercisesManager.Model.Queries.Unit;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.Unit;

public interface IUnitQueryService
{
    Task<IReadOnlyCollection<UnitResponse>> Handle(GetAllUnitsQuery query);
    Task<UnitResponse?> Handle(GetUnitByIdQuery query);
}