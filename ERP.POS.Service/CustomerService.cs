using AutoMapper;
using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using ERP.POS.Service.IServices;
using System.Linq.Expressions;

namespace ERP.POS.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            _unitOfWork.Repository<Customer>().Add(customer);
        }

        public async Task AddAsync(CustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            await _unitOfWork.Repository<Customer>().AddAsync(customer);
        }

        public void Delete(Guid id)
        {
            Customer? customer = _Get(x => x.Id == id);
            if (customer != null)
            {
                _unitOfWork.Repository<Customer>().Delete(customer);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            Customer? customer = await _GetAsync(x => x.Id == id);
            if (customer != null)
            {
                await _unitOfWork.Repository<Customer>().DeleteAsync(customer);
            }
        }

        public CustomerDto? Get(Expression<Func<Customer, bool>> filter)
        {
            Customer? customer = _Get(filter);
            return customer != null ? _mapper.Map<CustomerDto>(customer) : null;
        }

        public async Task<CustomerDto?> GetAsync(Expression<Func<Customer, bool>> filter)
        {
            Customer? customer = await _GetAsync(filter);
            return customer != null ? _mapper.Map<CustomerDto>(customer) : null;
        }

        public IEnumerable<CustomerDto> GetAll(Expression<Func<Customer, bool>>? filter = null)
        {
            var customersFromDb = _unitOfWork.Repository<Customer>().GetAll(filter);
            return _mapper.Map<IEnumerable<CustomerDto>>(customersFromDb);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync(Expression<Func<Customer, bool>>? filter = null)
        {
            var customersFromDb = await _unitOfWork.Repository<Customer>().GetAllAsync(filter);
            return _mapper.Map<IEnumerable<CustomerDto>>(customersFromDb);
        }

        public void Update(Guid id, CustomerDto customerDto)
        {
            Customer? customer = _Get(x => x.Id == id);
            if (customer != null)
            {
                _mapper.Map(customerDto, customer);
                _unitOfWork.Repository<Customer>().Update(customer);
            }
        }

        public async Task UpdateAsync(Guid id, CustomerDto customerDto)
        {
            Customer? customer = await _GetAsync(x => x.Id == id);
            if (customer != null)
            {
                _mapper.Map(customerDto, customer);
                await _unitOfWork.Repository<Customer>().UpdateAsync(customer);
            }
        }

        private Customer? _Get(Expression<Func<Customer, bool>> filter) => _unitOfWork.Repository<Customer>().Get(filter);
        private async Task<Customer?> _GetAsync(Expression<Func<Customer, bool>> filter) => await _unitOfWork.Repository<Customer>().GetAsync(filter);
    }

}
