using AutoMapper;
using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using ERP.POS.Service.IServices;
using System.Linq.Expressions;

namespace ERP.POS.Service
{
    public class CustomerBranchService : BaseService, ICustomerBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerBranchService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CustomerBranchDto customerBranchDto)
        {
            CustomerBranch customerBranch = _mapper.Map<CustomerBranch>(customerBranchDto);
            _unitOfWork.Repository<CustomerBranch>().Add(customerBranch);
        }

        public async Task AddAsync(CustomerBranchDto customerBranchDto)
        {
            CustomerBranch customerBranch = _mapper.Map<CustomerBranch>(customerBranchDto);
            await _unitOfWork.Repository<CustomerBranch>().AddAsync(customerBranch);
        }

        public void Delete(Guid id)
        {
            CustomerBranch? customerBranch = _Get(x => x.Id == id);
            if (customerBranch != null)
            {
                _unitOfWork.Repository<CustomerBranch>().Delete(customerBranch);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            CustomerBranch? customerBranch = await _GetAsync(x => x.Id == id);
            if (customerBranch != null)
            {
                await _unitOfWork.Repository<CustomerBranch>().DeleteAsync(customerBranch);
            }
        }

        public CustomerBranchDto? Get(Expression<Func<CustomerBranch, bool>> filter)
        {
            CustomerBranch? customerBranch = _Get(filter);
            return customerBranch != null ? _mapper.Map<CustomerBranchDto>(customerBranch) : null;
        }

        public async Task<CustomerBranchDto?> GetAsync(Expression<Func<CustomerBranch, bool>> filter)
        {
            CustomerBranch? customerBranch = await _GetAsync(filter);
            return customerBranch != null ? _mapper.Map<CustomerBranchDto>(customerBranch) : null;
        }

        public IEnumerable<CustomerBranchDto> GetAll(Expression<Func<CustomerBranch, bool>>? filter = null)
        {
            var customerBranchesFromDb = _unitOfWork.Repository<CustomerBranch>().GetAll(filter);
            return _mapper.Map<IEnumerable<CustomerBranchDto>>(customerBranchesFromDb);
        }

        public async Task<IEnumerable<CustomerBranchDto>> GetAllAsync(Expression<Func<CustomerBranch, bool>>? filter = null)
        {
            var customerBranchesFromDb = await _unitOfWork.Repository<CustomerBranch>().GetAllAsync(filter);
            return _mapper.Map<IEnumerable<CustomerBranchDto>>(customerBranchesFromDb);
        }

        public void Update(Guid id, CustomerBranchDto customerBranchDto)
        {
            CustomerBranch? customerBranch = _Get(x => x.Id == id);
            if (customerBranch != null)
            {
                _mapper.Map(customerBranchDto, customerBranch);
                _unitOfWork.Repository<CustomerBranch>().Update(customerBranch);
            }
        }

        public async Task UpdateAsync(Guid id, CustomerBranchDto customerBranchDto)
        {
            CustomerBranch? customerBranch = await _GetAsync(x => x.Id == id);
            if (customerBranch != null)
            {
                _mapper.Map(customerBranchDto, customerBranch);
                await _unitOfWork.Repository<CustomerBranch>().UpdateAsync(customerBranch);
            }
        }

        private CustomerBranch? _Get(Expression<Func<CustomerBranch, bool>> filter) => _unitOfWork.Repository<CustomerBranch>().Get(filter);
        private async Task<CustomerBranch?> _GetAsync(Expression<Func<CustomerBranch, bool>> filter) => await _unitOfWork.Repository<CustomerBranch>().GetAsync(filter);
    }

}
