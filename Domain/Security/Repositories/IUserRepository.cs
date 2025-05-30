using Domain.Security.Model.Entities;
using Domain.Security.Model.ValueObjects;
using Domain.Shared.Repository;

namespace Domain.Security.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<IReadOnlyCollection<User>> GetUsersByRoleAsync(UserRoles userRoles);
}