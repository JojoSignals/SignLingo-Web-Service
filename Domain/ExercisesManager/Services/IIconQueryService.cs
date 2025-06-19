using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services;

public interface IIconQueryService
{
    Task<IReadOnlyCollection<IconResponse>> Handle(GetAllIconsQuery query);
    
    Task<IconResponse?> Handle(GetIconByIdQuery query);
}