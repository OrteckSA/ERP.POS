using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using System.Linq.Expressions;

namespace ERP.POS.Service.IServices
{
    public interface ICustomerBranchService : IBaseService
    {
        CustomerBranchDto? Get(Expression<Func<CustomerBranch, bool>> filter);
        Task<CustomerBranchDto?> GetAsync(Expression<Func<CustomerBranch, bool>> filter);
        IEnumerable<CustomerBranchDto> GetAll(Expression<Func<CustomerBranch, bool>>? filter = null);
        Task<IEnumerable<CustomerBranchDto>> GetAllAsync(Expression<Func<CustomerBranch, bool>>? filter = null);
        void Add(CustomerBranchDto customerBranchDto);
        Task AddAsync(CustomerBranchDto customerBranchDto);
        void Update(Guid id, CustomerBranchDto customerBranchDto);
        Task UpdateAsync(Guid id, CustomerBranchDto customerBranchDto);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}
