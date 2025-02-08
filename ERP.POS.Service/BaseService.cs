using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Service.IServices;
using System.Linq.Expressions;

namespace ERP.POS.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _unitOfWork.Repository<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _unitOfWork.Repository<TEntity>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _unitOfWork.Repository<TEntity>().AddRangeAsync(entities);
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            return _unitOfWork.Repository<TEntity>().Get(filter);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.Repository<TEntity>().GetAll();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            var result = await _unitOfWork.Repository<TEntity>().GetAllAsync();
            return result.AsQueryable();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _unitOfWork.Repository<TEntity>().GetAsync(filter);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Update(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _unitOfWork.Repository<TEntity>().UpdateAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
