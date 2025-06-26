using System.ComponentModel.DataAnnotations;

namespace Application.ExercisesManager.Exceptions.Unit;

public class InvalidLengthOfUnitNameException : ValidationException
{
    public InvalidLengthOfUnitNameException() : base("Invalid length of unit name")
    {
        
    }
}