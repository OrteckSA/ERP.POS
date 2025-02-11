using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using System.Linq.Expressions;

namespace ERP.POS.Service.IServices
{
    public interface ICurrencyService : IBaseService
    {
        CurrencyDto? Get(Expression<Func<Currency, bool>> filter);
        Task<CurrencyDto?> GetAsync(Expression<Func<Currency, bool>> filter);
        IEnumerable<CurrencyDto> GetAll(Expression<Func<Currency, bool>>? filter = null);
        Task<IEnumerable<CurrencyDto>> GetAllAsync(Expression<Func<Currency, bool>>? filter = null);
        void Add(CurrencyDto currencyDto);
        Task AddAsync(CurrencyDto currencyDto);
        void AddRange(IEnumerable<CurrencyDto> currencyDtos);
        Task AddRangeAsync(IEnumerable<CurrencyDto> currencyDtos);
        void Update(Guid id, CurrencyDto currencyDto);
        Task UpdateAsync(Guid id, CurrencyDto currencyDto);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}
