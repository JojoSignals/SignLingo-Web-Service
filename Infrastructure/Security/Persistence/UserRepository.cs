using Domain.Security.Model.Entities;
using Domain.Security.Model.ValueObjects;
using Domain.Security.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Security.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .Where(user => user.Email == email && user.IsEnable)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .Where(user => user.Username == username && user.IsEnable)
            .FirstOrDefaultAsync();
    }
    
    public async Task<IReadOnlyCollection<User>> GetUsersByRoleAsync(UserRoles userRole)
    {
        return await _context.Users
            .Where(user => user.Role == userRole)
            .ToListAsync();
    }
}