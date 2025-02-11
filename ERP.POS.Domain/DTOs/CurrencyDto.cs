namespace ERP.POS.Domain.DTOs
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Rate { get; set; }
    }
}
