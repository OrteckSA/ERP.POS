using AutoMapper;
using ERP.POS.Domain.Common.IRepository;
using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using ERP.POS.Service.IServices;
using System.Linq.Expressions;

namespace ERP.POS.Service
{
    public class BillService : BaseService, IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(BillDto billDto)
        {
            Bill bill = _mapper.Map<Bill>(billDto);
            _unitOfWork.Repository<Bill>().Add(bill);
        }

        public async Task AddAsync(BillDto billDto)
        {
            Bill bill = _mapper.Map<Bill>(billDto);
            await _unitOfWork.Repository<Bill>().AddAsync(bill);
        }

        public void Delete(Guid id)
        {
            Bill? bill = _Get(x => x.Id == id);
            if (bill != null)
            {
                _unitOfWork.Repository<Bill>().Delete(bill);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            Bill? bill = await _GetAsync(x => x.Id == id);
            if (bill != null)
            {
                await _unitOfWork.Repository<Bill>().DeleteAsync(bill);
            }
        }

        public BillDto? Get(Expression<Func<Bill, bool>> filter)
        {
            Bill? bill = _Get(filter);

            if (bill != null)
            {
                return _mapper.Map<BillDto>(bill);
            }
            return null;
        }

        public async Task<BillDto?> GetAsync(Expression<Func<Bill, bool>> filter)
        {
            Bill? bill = await _GetAsync(filter);
            if (bill != null)
            {
                return _mapper.Map<BillDto>(bill);
            }
            return null;
        }

        public IEnumerable<BillDto> GetAll(Expression<Func<Bill, bool>>? filter = null)
        {
            var billsFromDb = _unitOfWork.Repository<Bill>().GetAll(filter);
            return _mapper.Map<IEnumerable<BillDto>>(billsFromDb);
        }

        public async Task<IEnumerable<BillDto>> GetAllAsync(Expression<Func<Bill, bool>>? filter = null)
        {
            var billsFromDb = await _unitOfWork.Repository<Bill>().GetAllAsync(filter);
            return _mapper.Map<IEnumerable<BillDto>>(billsFromDb);
        }

        public void Update(Guid id, BillDto billDto)
        {
            Bill? bill = _Get(x => x.Id == id);
            if (bill != null)
            {
                _mapper.Map(billDto, bill);
                _unitOfWork.Repository<Bill>().Update(bill);
            }
        }

        public async Task UpdateAsync(Guid id, BillDto billDto)
        {
            Bill? bill = await _GetAsync(x => x.Id == id);
            if (bill != null)
            {
                _mapper.Map(billDto, bill);
                await _unitOfWork.Repository<Bill>().UpdateAsync(bill);
            }
        }

        private Bill? _Get(Expression<Func<Bill, bool>> filter)
        {
            var query = _unitOfWork.Repository<Bill>().Include(
                s => s.Store,
                c => c.Currency,
                bi => bi.BillItems,
                Customer => Customer.Customer
            );

            return query.FirstOrDefault(filter);
        }

        private async Task<Bill?> _GetAsync(Expression<Func<Bill, bool>> filter) => await _unitOfWork.Repository<Bill>().GetAsync(filter);
    }
}
