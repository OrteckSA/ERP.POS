using ERP.POS.Domain.Entities;
using ERP.POS.Repository.EntityFrameworkCore.Context;
using ERP.POS.Repository.Repository.IRepository;

namespace ERP.POS.Repository.Repository
{
    public class CustomerRepository : Repository<TbCustomer>, ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
