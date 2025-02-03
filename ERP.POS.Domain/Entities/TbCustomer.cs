using ERP.POS.Domain.Common;
using ERP.POS.Domain.Common.Interfaces;

namespace ERP.POS.Domain.Entities
{
    public class TbCustomer : BaseEntity, INumberEntity
    {
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string LatinName { get; set; } = default!;
        public float DiscRatio { get; set; }
        public decimal MaximumSales { get; set; }
        public Guid ReferenceId { get; set; }

        public virtual ICollection<TbCustomerBranch> CustomerBranches { get; set; } = new List<TbCustomerBranch>();
    }
}
