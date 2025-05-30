using Domain.Shared;
using Domain.Shared.Repository;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
{
    protected readonly AppDbContext _context;
    
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().Where(t=> t.IsEnable).ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().Where(t => t.IsEnable && t.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null) return false;

        entity.IsEnable = false;
        return true;
    }
}