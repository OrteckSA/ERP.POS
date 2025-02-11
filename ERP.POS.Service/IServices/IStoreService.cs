using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using System.Linq.Expressions;

namespace ERP.POS.Service.IServices
{
    public interface IStoreService : IBaseService
    {
        StoreDto? Get(Expression<Func<Store, bool>> filter);
        Task<StoreDto?> GetAsync(Expression<Func<Store, bool>> filter);
        IEnumerable<StoreDto> GetAll(Expression<Func<Store, bool>>? filter = null);
        Task<IEnumerable<StoreDto>> GetAllAsync(Expression<Func<Store, bool>>? filter = null);
        void Add(StoreDto storeDto);
        Task AddAsync(StoreDto storeDto);
        void AddRange(IEnumerable<StoreDto> storeDtos);
        Task AddRangeAsync(IEnumerable<StoreDto> storeDtos);
        void Update(Guid id, StoreDto storeDto);
        Task UpdateAsync(Guid id, StoreDto storeDto);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}
