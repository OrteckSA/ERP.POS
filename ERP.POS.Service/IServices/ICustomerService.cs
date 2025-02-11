using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using System.Linq.Expressions;

namespace ERP.POS.Service.IServices
{
    public interface ICustomerService : IBaseService
    {
        CustomerDto? Get(Expression<Func<Customer, bool>> filter);
        Task<CustomerDto?> GetAsync(Expression<Func<Customer, bool>> filter);
        IEnumerable<CustomerDto> GetAll(Expression<Func<Customer, bool>>? filter = null);
        Task<IEnumerable<CustomerDto>> GetAllAsync(Expression<Func<Customer, bool>>? filter = null);
        void Add(CustomerDto customerDto);
        Task AddAsync(CustomerDto customerDto);
        void Update(Guid id, CustomerDto customerDto);
        Task UpdateAsync(Guid id, CustomerDto customerDto);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}
