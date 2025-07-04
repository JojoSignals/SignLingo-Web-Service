namespace Application.UserStats.ACL;

public interface IUserStatContextFacade
{
    public Task CreateUserStatWithUserId(int userId);
}
