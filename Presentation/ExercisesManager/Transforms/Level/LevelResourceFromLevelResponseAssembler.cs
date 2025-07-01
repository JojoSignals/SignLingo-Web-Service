using Domain.ExercisesManager.Model.Responses;
using Presentation.ExercisesManager.Resources.Icon;
using Presentation.ExercisesManager.Resources.Level;
using Presentation.ExercisesManager.Resources.Unit;

namespace Presentation.ExercisesManager.Transforms.Level;

public static class LevelResourceFromLevelResponseAssembler
{
    public static LevelResource ToResourceFromResponse(LevelResponse response)
    {
        return new LevelResource(
            response.LevelName,
            response.LevelDescription,
            response.ExperienceRequired,
            response.TotalQuestions,
            new UnitResource(response.Unit.Name),
            new IconResource(response.Icon.UrlImage)
        );
    }

    public static ICollection<LevelResource> ToResourcesFromResponse(IReadOnlyCollection<LevelResponse> responses)
    {
        return responses.Select(ToResourceFromResponse).ToList();
    }
}