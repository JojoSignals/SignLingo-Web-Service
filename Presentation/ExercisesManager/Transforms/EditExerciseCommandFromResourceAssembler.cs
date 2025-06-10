using Domain.ExercisesManager.Model.Commands;
using Presentation.ExercisesManager.Resources;

namespace Presentation.ExercisesManager.Transforms;

public static class EditExerciseCommandFromResourceAssembler
{
    public static EditExerciseCommand ToCommandFromResource(int id, EditExerciseResource resource) =>
        new EditExerciseCommand(
            id,
            resource.QuestionWord
        );
}