using Domain.ExercisesManager.Model.Commands;
using Presentation.ExercisesManager.Resources;

namespace Presentation.ExercisesManager.Transforms;

public static class CreateExerciseCommandFromResourceAssembler
{
    public static CreateExerciseCommand ToCommandFromResource(CreateExerciseResource resource)
    {
        return new CreateExerciseCommand(resource.QuestionWord, resource.QuestionTypeId);
    }
}