using Domain.ExercisesManager.Model.Responses;
using Presentation.ExercisesManager.Resources.Exercise;
using Presentation.ExercisesManager.Transforms.ExerciceOption;

namespace Presentation.ExercisesManager.Transforms.Exercise;

public static class ExerciseResourceFromExerciseResponseAssembler
{
    public static ExerciseResource ToResourceFromResponse(ExerciseResponse response)
    {
        var optionsResources = ExerciseOptionResourceFromExerciseOptionResource.ToResourcesFromResponse(response.ExerciseOptions);
        return new ExerciseResource(
            response.Id,
            optionsResources
        );
    }

    public static IReadOnlyCollection<ExerciseResource> ToResourcesFromResponse(IReadOnlyCollection<ExerciseResponse> responses)
    {
        return [.. responses.Select(ToResourceFromResponse)];
    }
}
