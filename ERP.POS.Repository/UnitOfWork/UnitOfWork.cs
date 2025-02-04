using ERP.POS.Domain.Common.IRepository;
using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Repository.EntityFrameworkCore.Context;
using ERP.POS.Repository.Repository;

namespace ERP.POS.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(TEntity)))
            {
                _repositories[typeof(TEntity)] = new Repository<TEntity>(_context);
            }
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public void SaveChanges() => _context.SaveChanges();

        public async Task ExecuteInTransactionAsync(Func<Task> operation)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await operation();
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> operation)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                T result = await operation();
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
