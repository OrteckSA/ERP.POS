using ERP.POS.Domain.Common;

namespace ERP.POS.Domain.Entities
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Rate { get; set; }
    }
}