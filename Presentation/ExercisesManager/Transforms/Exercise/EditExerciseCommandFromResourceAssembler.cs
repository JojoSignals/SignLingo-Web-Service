using Domain.ExercisesManager.Model.Commands.Exercise;
using Presentation.ExercisesManager.Resources.Exercise;

namespace Presentation.ExercisesManager.Transforms.Exercise;

public static class EditExerciseCommandFromResourceAssembler
{
    public static EditExerciseCommand ToCommandFromResource(int id, EditExerciseResource resource) =>
        new EditExerciseCommand(
            id,
            resource.QuestionWord,
            resource.QuestionTypeId
        );
}