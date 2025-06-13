using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions;

public class InvalidLengthOfQuestionWordsException : ValidationException
{
    public InvalidLengthOfQuestionWordsException(): base("Invalid length of question words")
    {
        
    }
}