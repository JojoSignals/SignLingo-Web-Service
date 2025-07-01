using Domain.ExercisesManager.Model.Commands.Exercise;
using Presentation.ExercisesManager.Resources.Exercise;

namespace Presentation.ExercisesManager.Transforms.Exercise;

public static class CreateExerciseCommandFromResourceAssembler
{
    public static CreateExerciseCommand ToCommandFromResource(CreateExerciseResource resource)
    {
        return new CreateExerciseCommand(resource.QuestionWord, resource.QuestionTypeId, resource.LevelId);
    }
}