namespace ERP.POS.Domain.Entities.OwnedEntities
{
    public class Measurement
    {
        public string Unit { get; set; } = null!;
        public decimal UnitValue { get; set; }
    }
}