using ERP.POS.Domain.Common;

namespace ERP.POS.Domain.Entities
{
    public class BillItem : BaseEntity
    {
        public Guid BillId { get; set; }
        public Guid MaterialId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRatio { get; set; }

        #region Owned Entities
        public decimal DiscountValue { get; set; }
        public decimal DiscountRatio { get; set; }
        public decimal ExtraValue { get; set; }
        public decimal ExtraRatio { get; set; }
        public string Unit { get; set; } = null!;
        public decimal UnitValue { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Bill Bill { get; set; } = null!;
        public virtual Material Material { get; set; } = null!;
        #endregion
    }
}
