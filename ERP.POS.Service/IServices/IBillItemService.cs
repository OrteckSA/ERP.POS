using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using System.Linq.Expressions;

namespace ERP.POS.Service.IServices
{
    public interface IBillItemService : IBaseService
    {
        BillItemDto? Get(Expression<Func<BillItem, bool>> filter);
        Task<BillItemDto?> GetAsync(Expression<Func<BillItem, bool>> filter);
        IEnumerable<BillItemDto> GetAll(Expression<Func<BillItem, bool>>? filter = null);
        Task<IEnumerable<BillItemDto>> GetAllAsync(Expression<Func<BillItem, bool>>? filter = null);
        void Add(BillItemDto billItemDto);
        Task AddAsync(BillItemDto billItemDto);
        void Update(Guid id, BillItemDto billItemDto);
        Task UpdateAsync(Guid id, BillItemDto billItemDto);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}
