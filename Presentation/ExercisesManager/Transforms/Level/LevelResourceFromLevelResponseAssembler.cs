using System.Text.Json;
using Domain.ExercisesManager.Model.Responses;
using Presentation.ExercisesManager.Resources.Exercise;
using Presentation.ExercisesManager.Resources.Icon;
using Presentation.ExercisesManager.Resources.Level;
using Presentation.ExercisesManager.Resources.Unit;
using Presentation.ExercisesManager.Transforms.Exercise;

namespace Presentation.ExercisesManager.Transforms.Level;

public static class LevelResourceFromLevelResponseAssembler
{
    public static LevelResource ToResourceFromResponse(LevelResponse response)
    {

        var exerciseResources = response.LevelExercises.Select(l =>
            ExerciseResourceFromExerciseOptionDomainAssembler.ToResourceFromDomain(l.ExerciseOptions)).ToList();
            
            
            
            
            // ExerciseResourceFromExerciseOptionDomainAssembler.ToResourceFromDomain(
            // response.LevelExercises.Select(l => l.ExerciseOptions)
                
        return new LevelResource(
            response.LevelName,
            response.LevelDescription,
            response.ExperienceRequired,
            response.TotalQuestions,
            new UnitResource(response.Unit.Id, response.Unit.Name),
            new IconResource(response.Icon.Id, response.Icon.UrlImage),
            exerciseResources
        );
    }

    public static ICollection<LevelResource> ToResourcesFromResponse(IReadOnlyCollection<LevelResponse> responses)
    {
        return responses.Select(ToResourceFromResponse).ToList();
    }
}