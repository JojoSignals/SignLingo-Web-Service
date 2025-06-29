using Domain.ExercisesManager.Model.Queries.Option;
using Domain.ExercisesManager.Model.Responses;

namespace Domain.ExercisesManager.Services.Option;

public interface IOptionQueryService
{
    Task<IReadOnlyCollection<OptionResponse>> Handle(GetAllOptionsQuery query);
    
    Task<OptionResponse?> Handle(GetOptionByIdQuery query);
}