using AutoMapper;
using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using ERP.POS.Service.IServices;
using System.Linq.Expressions;

namespace ERP.POS.Service
{
    public class MaterialService : BaseService, IMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaterialService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(MaterialDto materialDto)
        {
            Material material = _mapper.Map<Material>(materialDto);

            _unitOfWork.Repository<Material>().Add(material);
        }

        public async Task AddAsync(MaterialDto materialDto)
        {
            Material material = _mapper.Map<Material>(materialDto);

            await _unitOfWork.Repository<Material>().AddAsync(material);
        }

        public void AddRange(IEnumerable<MaterialDto> materialDtos)
        {
            IEnumerable<Material> materials = _mapper.Map<IEnumerable<Material>>(materialDtos);
            _unitOfWork.Repository<Material>().AddRange(materials);
        }

        public async Task AddRangeAsync(IEnumerable<MaterialDto> materialDtos)
        {
            IEnumerable<Material> materials = _mapper.Map<IEnumerable<Material>>(materialDtos);
            await _unitOfWork.Repository<Material>().AddRangeAsync(materials);
        }

        public void Delete(Guid id)
        {
            Material? material = _Get(x => x.Id == id);

            if (material != null)
            {
                _unitOfWork.Repository<Material>().Delete(material);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            Material? material = await _GetAsync(x => x.Id == id);

            if (material != null)
            {
                await _unitOfWork.Repository<Material>().DeleteAsync(material);
            }
        }

        public MaterialDto? Get(Expression<Func<Material, bool>> filter)
        {
            Material? material = _Get(filter);

            if (material != null)
            {
                return _mapper.Map<MaterialDto>(material);
            }

            return null;
        }

        public async Task<MaterialDto?> GetAsync(Expression<Func<Material, bool>> filter)
        {
            Material? material = await _GetAsync(filter);

            if (material != null)
            {
                return _mapper.Map<MaterialDto>(material);
            }

            return null;
        }

        public IEnumerable<MaterialDto> GetAll(Expression<Func<Material, bool>>? filter = null)
        {
            var materialsFromDb = _unitOfWork.Repository<Material>().GetAll(filter);

            return _mapper.Map<IEnumerable<MaterialDto>>(materialsFromDb);
        }

        public async Task<IEnumerable<MaterialDto>> GetAllAsync(Expression<Func<Material, bool>>? filter = null)
        {
            var materialsFromDb = await _unitOfWork.Repository<Material>().GetAllAsync(filter);

            return _mapper.Map<IEnumerable<MaterialDto>>(materialsFromDb);
        }

        public void Update(Guid id, MaterialDto materialDto)
        {
            Material? material = _Get(x => x.Id == id);

            if (material != null)
            {
                _mapper.Map(materialDto, material);
                _unitOfWork.Repository<Material>().Update(material);
            }
        }

        public async Task UpdateAsync(Guid id, MaterialDto materialDto)
        {
            Material? material = await _GetAsync(x => x.Id == id);

            if (material != null)
            {
                _mapper.Map(materialDto, material);
                await _unitOfWork.Repository<Material>().UpdateAsync(material);
            }
        }

        private Material? _Get(Expression<Func<Material, bool>> filter) => _unitOfWork.Repository<Material>().Get(filter);
        private async Task<Material?> _GetAsync(Expression<Func<Material, bool>> filter) => await _unitOfWork.Repository<Material>().GetAsync(filter);
    }
}
