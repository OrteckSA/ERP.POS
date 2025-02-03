using ERP.POS.Domain.IRepository;

namespace ERP.POS.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Performs an asynchronous operation with layer of transaction.
        /// </summary>
        /// <exception cref="Exception">Thrown when an error occurs during the operation and safely rollback the operations.</exception>
        Task UsingTransactionAsync(Func<Task> task);

        /// <summary>
        /// Performs an operation with layer of transaction.
        /// </summary>
        /// <exception cref="Exception">Thrown when an error occurs during the operation and safely rollback the operations.</exception>
        void UsingTransaction(Action func);

        IRepository<T> Repository<T>() where T : class;
    }
}
