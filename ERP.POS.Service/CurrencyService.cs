using AutoMapper;
using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using ERP.POS.Service.IServices;
using System.Linq.Expressions;

namespace ERP.POS.Service
{
    public class CurrencyService : BaseService, ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CurrencyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CurrencyDto currencyDto)
        {
            Currency currency = _mapper.Map<Currency>(currencyDto);
            _unitOfWork.Repository<Currency>().Add(currency);
        }

        public async Task AddAsync(CurrencyDto currencyDto)
        {
            Currency currency = _mapper.Map<Currency>(currencyDto);
            await _unitOfWork.Repository<Currency>().AddAsync(currency);
        }

        public void AddRange(IEnumerable<CurrencyDto> currencyDtos)
        {
            IEnumerable<Currency> currencies = _mapper.Map<IEnumerable<Currency>>(currencyDtos);
            _unitOfWork.Repository<Currency>().AddRange(currencies);
        }

        public async Task AddRangeAsync(IEnumerable<CurrencyDto> currencyDtos)
        {
            IEnumerable<Currency> currencies = _mapper.Map<IEnumerable<Currency>>(currencyDtos);
            await _unitOfWork.Repository<Currency>().AddRangeAsync(currencies);
        }

        public void Delete(Guid id)
        {
            Currency? currency = _Get(x => x.Id == id);
            if (currency != null)
            {
                _unitOfWork.Repository<Currency>().Delete(currency);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            Currency? currency = await _GetAsync(x => x.Id == id);
            if (currency != null)
            {
                await _unitOfWork.Repository<Currency>().DeleteAsync(currency);
            }
        }

        public CurrencyDto? Get(Expression<Func<Currency, bool>> filter)
        {
            Currency? currency = _Get(filter);
            return currency != null ? _mapper.Map<CurrencyDto>(currency) : null;
        }

        public async Task<CurrencyDto?> GetAsync(Expression<Func<Currency, bool>> filter)
        {
            Currency? currency = await _GetAsync(filter);
            return currency != null ? _mapper.Map<CurrencyDto>(currency) : null;
        }

        public IEnumerable<CurrencyDto> GetAll(Expression<Func<Currency, bool>>? filter = null)
        {
            var currenciesFromDb = _unitOfWork.Repository<Currency>().GetAll(filter);
            return _mapper.Map<IEnumerable<CurrencyDto>>(currenciesFromDb);
        }

        public async Task<IEnumerable<CurrencyDto>> GetAllAsync(Expression<Func<Currency, bool>>? filter = null)
        {
            var currenciesFromDb = await _unitOfWork.Repository<Currency>().GetAllAsync(filter);
            return _mapper.Map<IEnumerable<CurrencyDto>>(currenciesFromDb);
        }

        public void Update(Guid id, CurrencyDto currencyDto)
        {
            Currency? currency = _Get(x => x.Id == id);
            if (currency != null)
            {
                _mapper.Map(currencyDto, currency);
                _unitOfWork.Repository<Currency>().Update(currency);
            }
        }

        public async Task UpdateAsync(Guid id, CurrencyDto currencyDto)
        {
            Currency? currency = await _GetAsync(x => x.Id == id);
            if (currency != null)
            {
                _mapper.Map(currencyDto, currency);
                await _unitOfWork.Repository<Currency>().UpdateAsync(currency);
            }
        }

        private Currency? _Get(Expression<Func<Currency, bool>> filter) => _unitOfWork.Repository<Currency>().Get(filter);
        private async Task<Currency?> _GetAsync(Expression<Func<Currency, bool>> filter) => await _unitOfWork.Repository<Currency>().GetAsync(filter);
    }
}
