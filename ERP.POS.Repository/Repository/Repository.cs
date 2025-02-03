using ERP.POS.Domain.Common.Interfaces;
using ERP.POS.Domain.IRepository;
using ERP.POS.Repository.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ERP.POS.Repository.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => _dbSet;

        #region Get
        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null ? _dbSet.AsEnumerable() : _dbSet.Where(filter).AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null ? await _dbSet.ToListAsync() : await _dbSet.Where(filter).ToListAsync();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }
        #endregion

        #region Add
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        #endregion

        #region Update
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask; // Async method pattern
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            await Task.CompletedTask; // Async method pattern
        }
        #endregion

        #region Delete
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            var entities = _dbSet.Where(filter).ToList();
            _dbSet.RemoveRange(entities);
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = await _dbSet.Where(filter).ToListAsync();
            _dbSet.RemoveRange(entities);
        }

        public void DeleteRange(IEnumerable<TEntity> items)
        {
            _dbSet.RemoveRange(items);
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> items)
        {
            _dbSet.RemoveRange(items);
            await Task.CompletedTask;
        }

        public void SoftDelete(TEntity entity)
        {
            if (entity is ISoftDeletable softDeletableEntity)
            {
                softDeletableEntity.IsDeleted = true;
                Update(entity);
            }
        }

        public async Task SoftDeleteAsync(TEntity entity)
        {
            if (entity is ISoftDeletable softDeletableEntity)
            {
                softDeletableEntity.IsDeleted = true;
                await UpdateAsync(entity);
            }
        }

        public void SoftDelete(Expression<Func<TEntity, bool>> filter)
        {
            var entities = _dbSet.Where(filter).ToList();
            foreach (var entity in entities)
            {
                SoftDelete(entity);
            }
        }

        public async Task SoftDeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = await _dbSet.Where(filter).ToListAsync();
            foreach (var entity in entities)
            {
                await SoftDeleteAsync(entity);
            }
        }
        #endregion
    }
}
