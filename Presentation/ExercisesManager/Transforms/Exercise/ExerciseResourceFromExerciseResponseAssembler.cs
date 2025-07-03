using Domain.ExercisesManager.Model.Responses;
using Presentation.ExercisesManager.Resources.Exercise;

namespace Presentation.ExercisesManager.Transforms.Exercise;

public static class ExerciseResourceFromExerciseResponseAssembler
{
    public static ExerciseResource ToResourceFromResponse(ExerciseResponse response)
    {
        return new ExerciseResource(
            response.Id,
            []
        );
    }

    public static IReadOnlyCollection<ExerciseResource> ToResourcesFromResponse(IReadOnlyCollection<ExerciseResponse> responses)
    {
        return [.. responses.Select(ToResourceFromResponse)];
    }
}
