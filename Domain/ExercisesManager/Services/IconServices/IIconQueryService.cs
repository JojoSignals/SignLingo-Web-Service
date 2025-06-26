using Domain.ExercisesManager.Model.Queries.IconQueries;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.IconServices;

public interface IIconQueryService
{
    Task<IReadOnlyCollection<IconResponse>> Handle(GetAllIconsQuery query);
    
    Task<IconResponse?> Handle(GetIconByIdQuery query);
}