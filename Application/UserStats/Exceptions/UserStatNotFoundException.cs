namespace Application.UserStats.Exceptions;

public class UserStatNotFoundException : Exception
{
    public UserStatNotFoundException(int userId)
        : base($"No se encontraron estadísticas para el usuario con ID {userId}.")
    {
    }
}