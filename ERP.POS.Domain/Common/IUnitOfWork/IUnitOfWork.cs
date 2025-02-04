using ERP.POS.Domain.Common.IRepository;

namespace ERP.POS.Domain.Common.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task SaveChangesAsync();
        void SaveChanges();

        void StartTransaction();
        Task StartTransactionAsync();

        void Commit();
        Task CommitAsync();

        void Rollback();
        Task RollbackAsync();
    }
}
