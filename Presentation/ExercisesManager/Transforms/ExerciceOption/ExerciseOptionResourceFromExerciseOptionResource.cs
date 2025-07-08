using Domain.ExercisesManager.Model.Responses;
using Presentation.ExercisesManager.Resources.ExerciseOption;

namespace Presentation.ExercisesManager.Transforms.ExerciceOption;
public static class ExerciseOptionResourceFromExerciseOptionResource
{
    public static ExerciseOptionResource ToResourceFromResponse(ExerciseOptionResponse response)
    {
        return new ExerciseOptionResource(
            response.Option?.Id ?? 0,
            response.Option?.Word ?? "Not working",
            response.Option?.UrlImage ?? "Not showing",
            response.IsCorrect,
            response.Option?.MediaType.ToString() ?? "Not showing"
        );
    }

    public static IReadOnlyCollection<ExerciseOptionResource> ToResourcesFromResponse(IReadOnlyCollection<ExerciseOptionResponse> responses)
    {
        return [.. responses.Select(ToResourceFromResponse)];
    }
}
