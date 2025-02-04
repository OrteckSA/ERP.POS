using ERP.POS.Domain.Entities;
using ERP.POS.Repository.EntityFrameworkCore.Context;
using ERP.POS.Repository.Repository.IRepository;

namespace ERP.POS.Repository.Repository
{
    public class CustomerBranchRepository : Repository<TbCustomerBranch>, ICustomerBranchRepository
    {
        private readonly AppDbContext _context;

        public CustomerBranchRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
