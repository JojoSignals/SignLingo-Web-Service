namespace Domain.Security.Services;
public interface IUserStatContextService
{
    public Task<bool> CreateUserStat(int userId);
}
