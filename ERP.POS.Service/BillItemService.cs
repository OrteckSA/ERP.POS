using AutoMapper;
using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using ERP.POS.Service.IServices;
using System.Linq.Expressions;

namespace ERP.POS.Service
{
    public class BillItemService : BaseService, IBillItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillItemService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(BillItemDto billItemDto)
        {
            BillItem billItem = _mapper.Map<BillItem>(billItemDto);
            _unitOfWork.Repository<BillItem>().Add(billItem);
        }

        public async Task AddAsync(BillItemDto billItemDto)
        {
            BillItem billItem = _mapper.Map<BillItem>(billItemDto);
            await _unitOfWork.Repository<BillItem>().AddAsync(billItem);
        }

        public void Delete(Guid id)
        {
            BillItem? billItem = _Get(x => x.Id == id);
            if (billItem != null)
            {
                _unitOfWork.Repository<BillItem>().Delete(billItem);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            BillItem? billItem = await _GetAsync(x => x.Id == id);
            if (billItem != null)
            {
                await _unitOfWork.Repository<BillItem>().DeleteAsync(billItem);
            }
        }

        public BillItemDto? Get(Expression<Func<BillItem, bool>> filter)
        {
            BillItem? billItem = _Get(filter);
            if (billItem != null)
            {
                return _mapper.Map<BillItemDto>(billItem);
            }
            return null;
        }

        public async Task<BillItemDto?> GetAsync(Expression<Func<BillItem, bool>> filter)
        {
            BillItem? billItem = await _GetAsync(filter);
            if (billItem != null)
            {
                return _mapper.Map<BillItemDto>(billItem);
            }
            return null;
        }

        public IEnumerable<BillItemDto> GetAll(Expression<Func<BillItem, bool>>? filter = null)
        {
            var billItemsFromDb = _unitOfWork.Repository<BillItem>().GetAll(filter);
            return _mapper.Map<IEnumerable<BillItemDto>>(billItemsFromDb);
        }

        public async Task<IEnumerable<BillItemDto>> GetAllAsync(Expression<Func<BillItem, bool>>? filter = null)
        {
            var billItemsFromDb = await _unitOfWork.Repository<BillItem>().GetAllAsync(filter);
            return _mapper.Map<IEnumerable<BillItemDto>>(billItemsFromDb);
        }

        public void Update(Guid id, BillItemDto billItemDto)
        {
            BillItem? billItem = _Get(x => x.Id == id);
            if (billItem != null)
            {
                _mapper.Map(billItemDto, billItem);
                _unitOfWork.Repository<BillItem>().Update(billItem);
            }
        }

        public async Task UpdateAsync(Guid id, BillItemDto billItemDto)
        {
            BillItem? billItem = await _GetAsync(x => x.Id == id);
            if (billItem != null)
            {
                _mapper.Map(billItemDto, billItem);
                await _unitOfWork.Repository<BillItem>().UpdateAsync(billItem);
            }
        }

        private BillItem? _Get(Expression<Func<BillItem, bool>> filter) => _unitOfWork.Repository<BillItem>().Get(filter);
        private async Task<BillItem?> _GetAsync(Expression<Func<BillItem, bool>> filter) => await _unitOfWork.Repository<BillItem>().GetAsync(filter);
    }

}
