using Domain.ExercisesManager.Model.Aggregates;
using Presentation.ExercisesManager.Resources.Exercise;

namespace Presentation.ExercisesManager.Transforms.Exercise;

public static class ExerciseResourceFromExerciseOptionDomainAssembler
{
    public static ExerciseResource ToResourceFromDomain(IReadOnlyCollection<ExerciseOption> exerciseOptions)
    {
        List<ExerciseOptionResource> exerciseOptionResources = new List<ExerciseOptionResource>();
        foreach (var exerciseOption in exerciseOptions)
        {
            exerciseOptionResources.Add(
                new ExerciseOptionResource(
                    exerciseOption.Option.Id,
                    exerciseOption.Option.Word,
                    exerciseOption.Option.UrlImage,
                    exerciseOption.IsCorrect
                    )
                );
        }

        return new ExerciseResource(
            exerciseOptions.ElementAt(0).ExerciseId,
            exerciseOptionResources
        );
    }
}