using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions.Exercise;

public class DuplicateExerciseException : DuplicatedEntityAttributeException
{
    public DuplicateExerciseException(string atributo, object valor)
        : base("Ejercicio", atributo, valor)
    {
        
    }
}