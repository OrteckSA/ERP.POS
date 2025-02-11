using AutoMapper;
using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using ERP.POS.Service.IServices;
using System.Linq.Expressions;

namespace ERP.POS.Service
{
    public class StoreService : BaseService, IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(StoreDto storeDto)
        {
            Store store = _mapper.Map<Store>(storeDto);

            _unitOfWork.Repository<Store>().Add(store);
        }

        public async Task AddAsync(StoreDto storeDto)
        {
            Store store = _mapper.Map<Store>(storeDto);

            await _unitOfWork.Repository<Store>().AddAsync(store);
        }

        public void AddRange(IEnumerable<StoreDto> storeDtos)
        {
            IEnumerable<Store> stores = _mapper.Map<IEnumerable<Store>>(storeDtos);
            _unitOfWork.Repository<Store>().AddRange(stores);
        }

        public async Task AddRangeAsync(IEnumerable<StoreDto> storeDtos)
        {
            IEnumerable<Store> stores = _mapper.Map<IEnumerable<Store>>(storeDtos);
            await _unitOfWork.Repository<Store>().AddRangeAsync(stores);
        }

        public void Delete(Guid id)
        {
            Store? store = _Get(x => x.Id == id);

            if (store != null)
            {
                _unitOfWork.Repository<Store>().Delete(store);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            Store? store = await _GetAsync(x => x.Id == id);

            if (store != null)
            {
                await _unitOfWork.Repository<Store>().DeleteAsync(store);
            }
        }

        public StoreDto? Get(Expression<Func<Store, bool>> filter)
        {
            Store? store = _Get(filter);

            if (store != null)
            {
                return _mapper.Map<StoreDto>(store);
            }

            return null;
        }

        public async Task<StoreDto?> GetAsync(Expression<Func<Store, bool>> filter)
        {
            Store? store = await _GetAsync(filter);

            if (store != null)
            {
                return _mapper.Map<StoreDto>(store);
            }

            return null;
        }

        public IEnumerable<StoreDto> GetAll(Expression<Func<Store, bool>>? filter = null)
        {
            var storesFromDb = _unitOfWork.Repository<Store>().GetAll(filter);

            return _mapper.Map<IEnumerable<StoreDto>>(storesFromDb);
        }

        public async Task<IEnumerable<StoreDto>> GetAllAsync(Expression<Func<Store, bool>>? filter = null)
        {
            var storesFromDb = await _unitOfWork.Repository<Store>().GetAllAsync(filter);

            return _mapper.Map<IEnumerable<StoreDto>>(storesFromDb); ;
        }

        public void Update(Guid id, StoreDto storeDto)
        {

            Store? store = _Get(x => x.Id == id);

            if (store != null)
            {
                _mapper.Map(storeDto, store);
                _unitOfWork.Repository<Store>().Update(store);
            }
        }

        public async Task UpdateAsync(Guid id, StoreDto storeDto)
        {
            Store? store = await _GetAsync(x => x.Id == id);

            if (store != null)
            {
                _mapper.Map(storeDto, store);
                await _unitOfWork.Repository<Store>().UpdateAsync(store);
            }
        }

        private Store? _Get(Expression<Func<Store, bool>> filter) => _unitOfWork.Repository<Store>().Get(filter);
        private async Task<Store?> _GetAsync(Expression<Func<Store, bool>> filter) => await _unitOfWork.Repository<Store>().GetAsync(filter);
    }
}
