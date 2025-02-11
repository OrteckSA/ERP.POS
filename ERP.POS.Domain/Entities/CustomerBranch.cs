using ERP.POS.Domain.Common;

namespace ERP.POS.Domain.Entities
{
    public class CustomerBranch : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}
