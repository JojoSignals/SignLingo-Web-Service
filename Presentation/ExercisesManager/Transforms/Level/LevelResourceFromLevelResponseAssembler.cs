using System.Text.Json;
using Domain.ExercisesManager.Model.Responses;
using Presentation.ExercisesManager.Resources.Exercise;
using Presentation.ExercisesManager.Resources.Icon;
using Presentation.ExercisesManager.Resources.Level;
using Presentation.ExercisesManager.Resources.Unit;
using Presentation.ExercisesManager.Transforms.Exercise;
using Presentation.ExercisesManager.Transforms.Icon;
using Presentation.ExercisesManager.Transforms.Unit;

namespace Presentation.ExercisesManager.Transforms.Level;

public static class LevelResourceFromLevelResponseAssembler
{
    public static LevelResource ToResourceFromResponse(LevelResponse response)
    {
        var exercicesResources = ExerciseResourceFromExerciseResponseAssembler.ToResourcesFromResponse(response.Exercises);
        return new LevelResource(
            response.Id,
            response.Name,
            response.ExperienceRequired,
            response.Exercises.Count,
            UnitResourceFromUnitResponseAssembler.ToResourceFromResponse(response.Unit),
            IconResourceFromIconResponseAssembler.ToResourceFromResponse(response.Icon),
            exercicesResources
            );
        //var exerciseResources = response.Exercises.Select(l =>
        //    ExerciseResourceFromExerciseOptionDomainAssembler.ToResourceFromDomain(l.ExerciseOptions)).ToList();




        // ExerciseResourceFromExerciseOptionDomainAssembler.ToResourceFromDomain(
        // response.LevelExercises.Select(l => l.ExerciseOptions)

        //return new LevelResource(
        //    response.LevelName,
        //    response.LevelDescription,
        //    response.ExperienceRequired,
        //    response.TotalQuestions,
        //    new UnitResource(response.Unit.Id, response.Unit.Name),
        //    new IconResource(response.Icon.Id, response.Icon.UrlImage),
        //    exerciseResources
        //);
    }

    public static ICollection<LevelResource> ToResourcesFromResponse(IReadOnlyCollection<LevelResponse> responses)
    {
        return responses.Select(ToResourceFromResponse).ToList();
    }
}