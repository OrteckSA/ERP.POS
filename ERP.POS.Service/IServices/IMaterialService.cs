using ERP.POS.Domain.DTOs;
using ERP.POS.Domain.Entities;
using System.Linq.Expressions;

namespace ERP.POS.Service.IServices
{
    public interface IMaterialService : IBaseService
    {
        MaterialDto? Get(Expression<Func<Material, bool>> filter);
        Task<MaterialDto?> GetAsync(Expression<Func<Material, bool>> filter);
        IEnumerable<MaterialDto> GetAll(Expression<Func<Material, bool>>? filter = null);
        Task<IEnumerable<MaterialDto>> GetAllAsync(Expression<Func<Material, bool>>? filter = null);
        void Add(MaterialDto materialDto);
        Task AddAsync(MaterialDto materialDto);
        void AddRange(IEnumerable<MaterialDto> materialDtos);
        Task AddRangeAsync(IEnumerable<MaterialDto> materialDtos);
        void Update(Guid id, MaterialDto materialDto);
        Task UpdateAsync(Guid id, MaterialDto materialDto);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}
