namespace ERP.POS.Domain.DTOs
{
    public class BillDto
    {
        public Guid Id { get; set; }
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
        public StoreDto Store { get; set; } = null!;
        public CustomerDto Customer { get; set; } = null!;
        public CurrencyDto Currency { get; set; } = null!;
        public IEnumerable<BillItemDto> BillItems { get; set; } = [];
        #endregion
    }
}
