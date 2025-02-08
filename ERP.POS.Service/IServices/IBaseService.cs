using System.Linq.Expressions;

namespace ERP.POS.Service.IServices
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> fillter);
        TEntity? Get(Expression<Func<TEntity, bool>> fillter);
        Task<IQueryable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll();
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity);
        void AddRange(IEnumerable<TEntity> entity);
        Task UpdateAsync(TEntity entity);
        void Update(TEntity entity);

        Task SaveChangesAsync();
        void SaveChanges();
    }
} 
