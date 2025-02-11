namespace ERP.POS.Domain.DTOs
{
    public class BillItemDto
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public Guid MaterialId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRatio { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal DiscountRatio { get; set; }
        public decimal ExtraValue { get; set; }
        public decimal ExtraRatio { get; set; }
        public string Unit { get; set; } = null!;
        public decimal UnitValue { get; set; }

        #region Navigation Properties
        // public BillDto Bill { get; set; } = null!;
        public MaterialDto Material { get; set; } = null!;
        #endregion
    }
}
