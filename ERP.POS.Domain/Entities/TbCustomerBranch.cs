using ERP.POS.Domain.Common;

namespace ERP.POS.Domain.Entities
{
    public class TbCustomerBranch : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = null!;

        public virtual TbCustomer Customer { get; set; }
    }
}
