using ERP.POS.Domain.Common.IUnitOfWork;
using ERP.POS.Domain.Entities;
using ERP.POS.Service.IServices;

namespace ERP.POS.Service
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
