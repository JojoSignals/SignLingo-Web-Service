using Domain.ExercisesManager.Model.Responses;
using Presentation.ExercisesManager.Resources.Icon;

namespace Presentation.ExercisesManager.Transforms.Icon;

public static class IconResourceFromIconResponseAssembler
{
    public static IconResource ToResourceFromResponse(IconResponse response)
    {
        return new IconResource(response.UrlImage);
    }
    
    public static ICollection<IconResource> ToResourcesFromResponse(IReadOnlyCollection<IconResponse> responses)
    {
        return responses.Select(ToResourceFromResponse).ToList();
    }
}