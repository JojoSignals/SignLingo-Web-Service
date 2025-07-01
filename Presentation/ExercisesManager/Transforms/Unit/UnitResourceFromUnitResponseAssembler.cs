using Domain.ExercisesManager.Model.Responses;
using Presentation.ExercisesManager.Resources.Unit;

namespace Presentation.ExercisesManager.Transforms.Unit;

public static class UnitResourceFromUnitResponseAssembler
{
    public static UnitResource ToResourceFromResponse(UnitResponse response)
    {
        return new UnitResource(response.Name);
    }

    public static ICollection<UnitResource> ToResourcesFromResponses(IReadOnlyCollection<UnitResponse> responses)
    {
        return responses.Select(ToResourceFromResponse).ToList();
    }
}