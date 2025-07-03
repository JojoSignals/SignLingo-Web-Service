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
    
    public async Task<TEntity> AddAsync(TEntity entity)
    {
       var value =  await _context.Set<TEntity>().AddAsync(entity);
       
        if (value.Entity is null)
        {
            throw new InvalidOperationException("Failed to add entity.");
        }
        
        return value.Entity;
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        var query = IncludeNavigationProperties(_context.Set<TEntity>()).Where((t) => t.IsEnable);
        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        var query = IncludeNavigationProperties(_context.Set<TEntity>()).Where(t => t.Id == id && t.IsEnable);
        return await query.FirstOrDefaultAsync();
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

    protected virtual IQueryable<TEntity> IncludeNavigationProperties(DbSet<TEntity> dbSet)
    {
        return dbSet;
    }
}