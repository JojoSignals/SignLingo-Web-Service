namespace Domain.Shared.Repository;

public interface IUnitOfWork
{
    Task CompleteAsync();
}