using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using System.Linq.Expressions;

namespace ERP.POS.Service.IServices
{
    public interface IBillService : IBaseService
    {
        BillDto? Get(Expression<Func<Bill, bool>> filter);
        Task<BillDto?> GetAsync(Expression<Func<Bill, bool>> filter);
        IEnumerable<BillDto> GetAll(Expression<Func<Bill, bool>>? filter = null);
        Task<IEnumerable<BillDto>> GetAllAsync(Expression<Func<Bill, bool>>? filter = null);
        void Add(BillDto billDto);
        Task AddAsync(BillDto billDto);
        void Update(Guid id, BillDto billDto);
        Task UpdateAsync(Guid id, BillDto billDto);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }

}
