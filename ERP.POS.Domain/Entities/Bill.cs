using ERP.POS.Domain.Common;
using ERP.POS.Domain.Entities.OwnedEntities;

namespace ERP.POS.Domain.Entities
{
    public class Bill : BaseEntity
    {
        public Guid StoreId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal CurrencyValue { get; set; }
        public decimal TaxRatio { get; set; }

        #region Owned Entities
        public Discount Discount { get; set; } = null!;
        public Extra Extra { get; set; } = null!;
        #endregion

        #region Navigation Properties
        public virtual Store Store { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Currency Currency { get; set; } = null!;
        public virtual ICollection<BillItem> BillItems { get; set; } = [];
        #endregion
    }
}
