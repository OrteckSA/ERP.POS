using ERP.POS.Domain.Common;
using ERP.POS.Domain.Entities.OwnedEntities;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Discount Discount { get; set; } = null!;
        public Extra Extra { get; set; } = null!;
        public Measurement Measurement { get; set; } = null!;
        #endregion

        #region Navigation Properties
        public virtual Bill Bill { get; set; } = null!;
        public virtual Material Material { get; set; } = null!;
        #endregion
    }
}
