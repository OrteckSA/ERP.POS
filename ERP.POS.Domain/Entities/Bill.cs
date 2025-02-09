using ERP.POS.Domain.Common;

namespace ERP.POS.Domain.Entities
{
    public class Bill : BaseEntity
    {
        public Guid StoreId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal CurrencyValue { get; set; }
        public decimal TaxRatio { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal DiscountRatio { get; set; }
        public decimal ExtraValue { get; set; }
        public decimal ExtraRatio { get; set; }

        #region Navigation Properties
        public virtual Store Store { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Currency Currency { get; set; } = null!;
        public virtual ICollection<BillItem> BillItems { get; set; } = [];
        #endregion
    }
}
