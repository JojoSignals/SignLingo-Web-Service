namespace Domain.Shared.Repository;

public interface IBaseRepository<TEntity> where TEntity : BaseModel
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);
}