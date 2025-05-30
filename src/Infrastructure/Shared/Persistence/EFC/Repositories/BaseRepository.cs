using Domain.Shared.Repository;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().Where(t => t.IsEnable).ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().Where(t => t.IsEnable && t.Id == id).FirstOrDefaultAsync();
    }

    public async Task<TEntity> SaveAsync(TEntity entity)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return entity;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception(ex.Message);
        }
    }

    public async Task<TEntity> ModifyAsync(TEntity entity)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return entity;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            entity!.IsEnable = false;
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return true;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}